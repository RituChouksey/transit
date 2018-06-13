using System;
using System.IO;
using System.Net;
using System.Net.Http;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("localhost:62351/distance/104/109", HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                Assert.NotNull(response.Content);
            }
            
        }


    }
}
