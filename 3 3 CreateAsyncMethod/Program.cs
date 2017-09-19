using System;
using System.Threading;
using System.Threading.Tasks;

namespace _3_3_CreateAsyncMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            //AsyncMain();

            HttpClientTest.Get();
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        static async void AsyncMain()
        {
            string s = await TestAsync();
            Console.WriteLine(s);
        }
        static Task<string> TestAsync()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(2000);
                return "Hello";
            });
        }
    }
}
