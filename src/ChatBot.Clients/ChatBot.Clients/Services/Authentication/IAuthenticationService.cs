using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.Clients.Core.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> LoginAsync(string email, string password);

        Task<bool> LoginWithFacebookAsync();

        Task LogoutAsync();
    }
}
