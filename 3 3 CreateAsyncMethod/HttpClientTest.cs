using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace _3_3_CreateAsyncMethod
{
    class HttpClientTest
    {
        public static async void Get()
        {
            HttpClient hc = new HttpClient();
            string html = await hc.GetStringAsync("http://bing.com");
            Console.WriteLine(html);
        }

        public static async void Post()
        {
            HttpClient hc = new HttpClient();
            string html = await hc.GetStringAsync("http://bing.com");
            Console.WriteLine(html);
        }
    }
}
