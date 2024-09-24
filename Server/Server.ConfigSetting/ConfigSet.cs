using Microsoft.Extensions.Configuration;
using Server.IConfigSetting;

namespace Server.ConfigSetting
{
    public class ConfigSet : IConfigSet
    {
        private static IConfigurationRoot configurationRoot;

        public ConfigSet()
        {
            var builder = new ConfigurationBuilder().
                        SetBasePath(Directory.GetCurrentDirectory()).
                        AddJsonFile("appsettings.json");
            configurationRoot = builder.Build();
        }

        public string Read(string key)
        {
            return configurationRoot[key];
        }
    }
}