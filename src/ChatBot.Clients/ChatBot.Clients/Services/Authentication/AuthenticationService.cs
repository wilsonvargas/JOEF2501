using ChatBot.Clients.Core.Services.Storage;
using System;
using System.Threading.Tasks;

namespace ChatBot.Clients.Core.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IBrowserCookiesService _browserCookiesService;
        private readonly IAvatarUrlProvider _avatarProvider;
        private readonly IStorageService _storageService;

        public AuthenticationService(
            IBrowserCookiesService browserCookiesService,
            IAvatarUrlProvider avatarProvider,
            IStorageService storageService)
        {
            _browserCookiesService = browserCookiesService;
            _avatarProvider = avatarProvider;
            _storageService = storageService;
        }

        public bool IsAuthenticated => AppSettings.User != null;

        public Models.User AuthenticatedUser => AppSettings.User;

        public async Task<bool> LoginAsync(string email, string password)
        {
            bool result = false;
            if (AppSettings.IsFake)
            {
                var user = new Models.User
                {
                    Email = email,
                    Name = email,
                    LastName = string.Empty,
                    AvatarUrl = _avatarProvider.GetAvatarUrl(email),
                    Token = email,
                    LoggedInWithFacebookAccount = false
                };

                AppSettings.User = user;

                return true;
            }
            else
            {
                Models.User user = await _storageService.GetUserAsync<Models.User>(email);

                if (user != null)
                {
                    if (user.Password == password)
                    {
                        AppSettings.User = user;
                        result = true;
                    }
                }
                return result;
            }
            
           
        }

        public async Task<bool> LoginWithFacebookAsync()
        {
            bool succeeded = false;

            //TODO: Make login with facebook

            return succeeded;
        }

        

        public async Task LogoutAsync()
        {
            AppSettings.RemoveUserData();
            await _browserCookiesService.ClearCookiesAsync();
        }

        
    }
}
