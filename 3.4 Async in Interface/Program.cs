using System;
using System.Threading.Tasks;

namespace _3._4_Async_in_Interface {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello World!");
      Call();
      Console.ReadKey();

    }
    static async void Call() {
      Console.WriteLine(await new Test().GetAsync(2));
    }

  }

  interface ITest {
    Task<string> GetAsync(int i);
  }

  public class Test : ITest {
    public Task<string> GetAsync(int i) {
      return Task.FromResult("aaa");
    }
  }
}
