using Microsoft.Extensions.Configuration;
using SMB_SaaS.Core.Models;

namespace SMB_SaaS.Core.Utilities
{
    public static class Configuration
    {
        public static Settings Settings => new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build().GetSection("Settings").Get<Settings>();       
    }
}
