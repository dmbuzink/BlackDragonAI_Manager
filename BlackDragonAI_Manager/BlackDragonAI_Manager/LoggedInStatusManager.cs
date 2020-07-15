using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackDragonAI_Manager.BlbApi.Models;
using Blazored.LocalStorage;

namespace BlackDragonAI_Manager
{
    public class LoggedInStatusManager
    {
        public bool CurrentUserLoggedInStatus { get; set; }
        public event Action<bool> UserLoggedIn;

        private User _user;

        public void SetLoggedInStatus(bool loggedInStatus)
        {
            CurrentUserLoggedInStatus = loggedInStatus;
            UserLoggedIn?.Invoke(loggedInStatus);
        }
    }
}
