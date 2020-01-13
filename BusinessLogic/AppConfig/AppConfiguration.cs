using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.AppConfig
{
    public static class AppConfiguration
    {
        private static IConfiguration currentConfig;

        public static void SetConfig(IConfiguration configuration)
        {
            currentConfig = configuration;
        }

        public static string GetConfiguration(string configKey) => "DefaultEndpointsProtocol=https;AccountName=ebsepam;AccountKey=JwkSPXC8Chfz9p9NYcj8otjmsFvT2Wn4qa4ipa6I68l23to9iKZg0ehW3y1GTXs+kqpY7JHPKI2D4pHcTZrOHw==;EndpointSuffix=core.windows.net";
    }
}
