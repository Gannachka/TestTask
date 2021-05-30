using Microsoft.Extensions.Configuration;
using System;

namespace Core
{
    public static class ApplicationConfig
    {
        public static int ExplicitTimeout => Convert.ToInt32(TestConfigurationManager.GetConfigurationRoot().GetValue<string>("ApplicationConfig:ExplicitTimeout"));
        public static BrowserName BrowserName => Enum.Parse<BrowserName>(TestConfigurationManager.GetConfigurationRoot().GetValue<string>("ApplicationConfig:Browser"));
        public static string URL => new string(TestConfigurationManager.GetConfigurationRoot().GetValue<string>("ApplicationConfig:URL"));

    }
}
