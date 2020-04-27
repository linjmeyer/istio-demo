using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace IstioDemoDotNet
{
    public class DemoEnvironment
    {
        public bool IsCanary { get; }
        public string EnvironmentName { get; }

        public DemoEnvironment(IWebHostEnvironment hostEnvironment)
        {
            // In debug mode fake some values
            if (hostEnvironment.IsDevelopment())
            {
                IsCanary = true;
                EnvironmentName = hostEnvironment.EnvironmentName;
                return;
            }
            
            // Else get them from env vars set by Spinnaker
            IsCanary = String.Equals(Environment.GetEnvironmentVariable("DEMO_IS_CANARY"), "true", StringComparison.OrdinalIgnoreCase);
            EnvironmentName = Environment.GetEnvironmentVariable("DEMO_ENVIRONMENT_NAME");
        }
    }
}