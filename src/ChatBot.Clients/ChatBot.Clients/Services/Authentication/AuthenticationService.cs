using System;
using System.Threading.Tasks;

namespace ChatBot.Clients.Core.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IBrowserCookiesService _browserCookiesService;
        private readonly IAvatarUrlProvider _avatarProvider;

        public AuthenticationService(
            IBrowserCookiesService browserCookiesService,
            IAvatarUrlProvider avatarProvider)
        {
            _browserCookiesService = browserCookiesService;
            _avatarProvider = avatarProvider;
        }

        public bool IsAuthenticated => AppSettings.User != null;

        public Models.User AuthenticatedUser => AppSettings.User;

        public Task<bool> LoginAsync(string email, string password)
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

            return Task.FromResult(true);
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
