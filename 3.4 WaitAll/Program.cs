using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace _3._4_WaitAll {
  class Program {
    static void Main(string[] args) {

      M1();
      Console.WriteLine("Hello World!");
      Console.ReadKey();
    }

    static async void M1() {
      //WebClient wc = new WebClient();
      //string s1 = await wc.DownloadStringTaskAsync("http://baidu.com");
      //string s2 = await wc.DownloadStringTaskAsync("http://qq.com");
      //Console.WriteLine(s1.Length);
      //Console.WriteLine(s2.Length);

      //HttpClient wc = new HttpClient();
      //string s1 = await wc.GetStringAsync("http://baidu.com");
      //string s2 = await wc.GetStringAsync("http://qq.com");
      //Console.WriteLine(s1.Length);
      //Console.WriteLine(s2.Length);

      HttpClient wc = new HttpClient();
      var s1 = wc.GetStringAsync("http://baidu.com");
      var s2 = wc.GetStringAsync("http://qq.com");
      await Task.WhenAll(s1, s2);
      Console.WriteLine(s1.Result.Length);
      Console.WriteLine(s2.Result.Length);
    }
  }
}
