using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackDragonAI_Manager.BlbApi.Models
{
    public class AuthOutput
    {
        public string Token { get; set; }
//        public int ExpiresInSeconds { get; set; } = 10 * 24 * 60 * 60;
        public EAuthorizationLevel AuthorizationLevel { get; set; } //= EAuthorizationLevel.NONE;
    }
}
