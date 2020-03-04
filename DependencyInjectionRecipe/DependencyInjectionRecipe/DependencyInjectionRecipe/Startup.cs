﻿using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Xamarin.Essentials;

namespace DependencyInjectionRecipe
{
    public static class Startup
    {
        public static void Init()
        {
            var configFile = ExtractResource("DependencyInjectionRecipe.appsettings.json",
                FileSystem.AppDataDirectory);

            var host = new HostBuilder().ConfigureHostConfiguration(c =>
            {
                // Tell the host configuration where to file the file (this is required for Xamarin apps)
                c.AddCommandLine(new[]
                {
                    $"ContentRoot={FileSystem.AppDataDirectory}"
                });

                //read in the configuration file!
                c.AddJsonFile(configFile);
            }).ConfigureServices(ConfigureServices).ConfigureLogging(l =>
                l.AddConsole(o =>
                {
                    //setup a console logger and disable colors since they don't have any colors in VS
                    o.DisableColors = true;
                })).Build();

            //Save our service provider so we can use it later.
            ServiceProvider.Provider = host.Services;
        }

        private static void ConfigureServices(HostBuilderContext ctx,
            IServiceCollection services)
        {
            // The HostingEnvironment comes from the appsetting.json and could be optionally used to configure the mock service
            if (ctx.HostingEnvironment.IsDevelopment())
            {
                services.AddSingleton<IDependencyExample, DevelopmentDependency>();
            }
        }

        private static string ExtractResource(string filename, string location)
        {
            var a = Assembly.GetExecutingAssembly();
            using (var resFilestream = a.GetManifestResourceStream(filename))
            {
                if (resFilestream != null)
                {
                    var full = Path.Combine(location, filename);

                    using (var stream = File.Create(full))
                    {
                        resFilestream.CopyTo(stream);
                    }
                }
            }

            return Path.Combine(location, filename);
        }
    }
}