using System;
using LastMiles.API;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;
using Microsoft.Extensions.Identity.Core;
using Microsoft.Extensions.Configuration;

namespace API_Tests
{
    public class Test_Server_Setup
    {
        TestServer testServer = null;
        public TestServer CreateServer()
        {
            var webHostBuilder = new WebHostBuilder();//WebHost.CreateDefaultBuilder();
            webHostBuilder
            //  .UseContentRoot(@"..\LastMiles.API")
            .UseEnvironment("Development")
            .UseConfiguration(new ConfigurationBuilder()
                                    .SetBasePath(@"C:\Users\Jonathan\Desktop\Distribution\LastMiles\LastMiles.API")
                                    .AddJsonFile("appsettings.json")
                                    .Build()
                             )
            .UseStartup<Startup>();
            testServer = new TestServer(webHostBuilder);

            return testServer;
        }


    }
}