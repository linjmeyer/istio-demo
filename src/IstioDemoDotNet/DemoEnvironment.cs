using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace IstioDemoDotNet
{
    public class DemoEnvironment
    {
        public string EnvironmentName { get; }

        public DemoEnvironment(IWebHostEnvironment hostEnvironment)
        {
            // In debug mode fake some values
            if (hostEnvironment.IsDevelopment())
            {
                EnvironmentName = "DEVELOPMENT";
                return;
            }
            
            // Else get them from env vars set by Spinnaker
            EnvironmentName = Environment.GetEnvironmentVariable("DEMO_ENVIRONMENT_NAME");
        }
    }
}