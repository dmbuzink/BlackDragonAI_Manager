using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using BlackDragonAI_Manager.BlbApi.Models;
using Newtonsoft.Json;
using Refit;

namespace BlackDragonAI_Manager.BlbApi
{
    public class BlbApiHandler
    {
        private readonly IBlbApi _blbApi;
        private string _jwt;
        private User _user;
        private Timer _timer;

        public BlbApiHandler(IBlbApi blbApi)
        {
            this._blbApi = blbApi;
        }

        public void SetupUser(User user)
        {
            this._user = user;
        }

        // Endpoints
        public async Task<AuthOutput> Authenticate()
        {
            var authResult = await _blbApi.Authenticate(this._user);
            this._jwt = authResult.Token;
            // setup reauth timer
            this._timer = new Timer(authResult.ExpiresInSeconds * 1000);
            this._timer.AutoReset = false;
            this._timer.Elapsed += (sender, args) => Authenticate().RunSynchronously();
            this._timer.Start();
            return authResult;
        }

        public Task<IEnumerable<CommandDetails>> GetAllCommands() =>
            _blbApi.GetCommands(this._jwt);

        public Task<CommandDetails> CreateCommand(CommandDetails commandDetails) =>
            _blbApi.CreateCommand(this._jwt, commandDetails);

        public Task<CommandDetails> EditCommand(CommandDetails commandDetails) =>
            _blbApi.EditCommand(this._jwt, commandDetails);

        public Task DeleteCommand(string commandName) =>
            _blbApi.DeleteCommand(this._jwt, commandName);

        public Task AddAlias(string commandName, string alias) =>
            _blbApi.AddAlias(this._jwt, commandName, new AliasInput() { Alias = alias });

        public Task DeleteAlias(string alias) =>
            _blbApi.DeleteAlias(this._jwt, alias);
    }

    public static class BlbApiExtensions
    {
        public static ApiError ToBlbApiError(this ApiException apiException) =>
            JsonConvert.DeserializeObject<ApiError>(apiException.Content);
    }
}
