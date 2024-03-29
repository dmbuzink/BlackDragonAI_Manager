using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BlackDragonAI_Manager.Models
{
    public class BlbApiConfig
    {
        public string Url { get; set; }
        public string JWT { get; private set; }
        public event Action<string> AuthenticationChanged;

        public BlbApiConfig() { }

        public BlbApiConfig(IConfigurationSection config)
        {
            this.Url = config.GetValue<string>("url");
        }

        public void SetJwt(string jwt)
        {
            this.JWT = jwt;
            AuthenticationChanged?.Invoke(jwt);
        }
    }
}
