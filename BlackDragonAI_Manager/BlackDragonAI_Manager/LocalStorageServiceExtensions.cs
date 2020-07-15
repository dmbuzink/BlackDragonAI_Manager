using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackDragonAI_Manager.BlbApi.Models;
using Blazored.LocalStorage;

namespace BlackDragonAI_Manager
{
    public static class LocalStorageServiceExtensions
    {
        private const string StorageKey = "user";

        public static async Task<bool> IsLoggedIn(this ILocalStorageService storageService) =>
            await storageService.ContainKeyAsync(StorageKey);

        public static async Task<User> GetUser(this ILocalStorageService storageService) =>
            await storageService.GetItemAsync<User>(StorageKey);

        public static async Task<EAuthorizationLevel> GetAuthorizationLevel(this ILocalStorageService storageService) =>
            (await storageService.GetUser()).AuthorizationLevel;

        public static async Task<bool> IsLoggedInAndMeetsAuthorizationLevel(this ILocalStorageService storageService,
            EAuthorizationLevel authLevel = EAuthorizationLevel.NONE) =>
            await storageService.IsLoggedIn() && await storageService.GetAuthorizationLevel() >= authLevel;
    }
}
