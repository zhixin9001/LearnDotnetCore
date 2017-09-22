using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace _3._6_Cannot_Async {
  class Program {
    static void Main(string[] args) {
      //Console.WriteLine("Hello World!");
      //HttpClient hc = new HttpClient();
      //var taskMsg = hc.GetAsync("http://www.rupeng.com");
      //var taskRead = taskMsg.Result;
      //Console.WriteLine(taskRead);
      var r = Test4Async().Result;
      Console.WriteLine(r);
      Console.ReadKey();
    }

    static Task<int> Test1Async() {
      return Task.Run(() => {
        return 1 + 1;
      });
    }

    static Task<int> Test2Async() {
      return Task.FromResult(3);
    }

    static async Task<int> Test3Async() {
      return 4;
    }

    static async Task<HttpResponseMessage> Test4Async() {
      HttpClient hc = new HttpClient();
      var taskMsg =await hc.GetAsync("http://www.rupeng.com");
      return taskMsg;
    }

  }
}
