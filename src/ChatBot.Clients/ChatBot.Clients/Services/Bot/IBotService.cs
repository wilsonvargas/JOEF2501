using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChatBot.Clients.Core.Models;

namespace ChatBot.Clients.Core.Services.Bot
{
    public interface IBotService
    {
        Task<Activity> Connect();
        Task<Activity> SendMessage(Activity message);
    }
}
