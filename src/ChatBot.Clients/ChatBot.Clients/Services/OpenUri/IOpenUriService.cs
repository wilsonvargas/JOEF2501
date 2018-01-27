using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot.Clients.Core.Services.OpenUri
{
    public interface IOpenUriService
    {
        void OpenUri(string uri);
        void OpenFacebookBot(string botId);
        void OpenSkypeBot(string botId);
    }
}
