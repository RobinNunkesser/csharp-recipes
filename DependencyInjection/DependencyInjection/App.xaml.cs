using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DependencyInjection;

public partial class App : Application
{
    // Constructor Injection
    public App(AppShell shell)
    {
        InitializeComponent();

        MainPage = shell;
    }

    /* ALternative: Manually obtain service
    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        MainPage = serviceProvider.GetService<AppShell>();
    }
    */
}

