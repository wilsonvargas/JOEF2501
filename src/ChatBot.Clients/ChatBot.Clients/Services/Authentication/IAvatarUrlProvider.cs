using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot.Clients.Core.Services.Authentication
{
    public interface IAvatarUrlProvider
    {
        string GetAvatarUrl(string email);
    }
}
