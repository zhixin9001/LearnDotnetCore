using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _3_MultiThread {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
      //EAP();
      //APM();
      TPL();
      Console.WriteLine("Waitting1");
      Console.ReadKey();
    }

    #region EAP

    private static void EAP() {
      WebClient wc = new WebClient();
      wc.DownloadStringCompleted += Wc_DownloadStringCompleted;
      wc.DownloadStringAsync(new Uri("http://www.github.com"));
      Console.WriteLine("Downloading");
    }
    private static void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e) {
      Console.WriteLine(e.Result);
    }
    #endregion

    #region APM
    private static void APM() {
      string filePath = "e:/文章汇总/083.20170906 .Net Core(二)EFCore.txt";
      using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
        var buffer = new byte[128];
        var asyncState = new AsyncState { FS = fileStream, Buffer = buffer, EvtHandle = new ManualResetEvent(false) };
        IAsyncResult asyncResult = fileStream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(AsyncReadCallBack), asyncState);
        asyncState.EvtHandle.WaitOne();
        Console.WriteLine();
        Console.WriteLine("read complete");
        Console.ReadKey();
      }
    }

    public static void AsyncReadCallBack(IAsyncResult asyncResult) {
      var asyncState = (AsyncState)asyncResult.AsyncState;
      int readCn = asyncState.FS.EndRead(asyncResult);
      if (readCn > 0) {
        byte[] buffer;
        if (readCn == 128) {
          buffer = asyncState.Buffer;
        }
        else {
          buffer = new byte[readCn];
          Array.Copy(asyncState.Buffer, 0, buffer, 0, readCn);
        }
        string readContent = Encoding.UTF8.GetString(buffer);
        Console.Write(readContent);

        if (readCn < 128) {
          asyncState.EvtHandle.Set();
        }
        else {
          Array.Clear(asyncState.Buffer, 0, 128);
          asyncState.FS.BeginRead(asyncState.Buffer, 0, 128, new AsyncCallback(AsyncReadCallBack), asyncState);
        }
      }
    }
    #endregion

    #region TPL
    async static void TPL() {
      string filePath = "e:/文章汇总/083.20170906 .Net Core(二)EFCore.txt";
      using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
        var buffer = new byte[128];
        var readLength = 0;
        while ((readLength = await fileStream.ReadAsync(buffer, 0, buffer.Length)) != 0) {
          string content = Encoding.UTF8.GetString(buffer);
          Console.WriteLine(content);
        }
        Console.WriteLine("complete");
      }
    }
    #endregion
    class AsyncState {
      public FileStream FS { get; set; }
      public byte[] Buffer { get; set; }
      public ManualResetEvent EvtHandle { get; set; }
    }


  }
}
