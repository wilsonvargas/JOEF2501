using System.Threading.Tasks;

namespace ChatBot.Clients.Core.Services.Authentication
{
    public interface IBrowserCookiesService
    {
        Task ClearCookiesAsync();
    }
}
