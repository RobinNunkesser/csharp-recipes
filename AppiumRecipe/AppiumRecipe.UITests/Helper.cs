using System;

namespace AppiumRecipe.UITests
{
    public static class Env
    {
        public static String rootDirectory = "/Users/nunkesser/Coding/Repos/appium/sample-code";

        public static Uri ServerUri() =>
            new Uri("http://localhost:4723/wd/hub");

        public static TimeSpan INIT_TIMEOUT_SEC = TimeSpan.FromSeconds(180);
        public static TimeSpan IMPLICIT_TIMEOUT_SEC = TimeSpan.FromSeconds(10);
    }

    public static class App
    {                
        static public String IOSApp() => $"{Env.rootDirectory}/apps/TestApp.app.zip";
        

        static public String IOSDeviceName() => Environment.GetEnvironmentVariable("IOS_DEVICE_NAME") ?? "iPhone 6s";
        

        static public String IOSPlatformVersion()
        {
            return Environment.GetEnvironmentVariable("IOS_PLATFORM_VERSION") ?? "12.2";
        }

        static public String AndroidApp()
        {
            return $"{Env.rootDirectory}/apps/ApiDemos-debug.apk";
        }

        static public String AndroidDeviceName()
        {
            return Environment.GetEnvironmentVariable("ANDROID_DEVICE_VERSION") ?? "Android";
        }

        static public String AndroidPlatformVersion()
        {
            return Environment.GetEnvironmentVariable("ANDROID_PLATFORM_VERSION") ?? "9";
        }
    }}