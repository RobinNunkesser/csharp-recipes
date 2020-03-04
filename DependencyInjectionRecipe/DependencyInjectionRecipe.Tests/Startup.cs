﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DependencyInjectionRecipe.Tests
{
    public static class Startup
    {
        public static void Init(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            ServiceProvider.Provider = host.Services;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureServices(
                (hostContext, services) =>
                {
                    services.AddSingleton<IDependencyExample, TestDependency>();
                });
    }
}