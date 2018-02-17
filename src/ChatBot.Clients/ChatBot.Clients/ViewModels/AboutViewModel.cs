using ChatBot.Clients.Core.Services.Authentication;
using ChatBot.Clients.Core.ViewModels.Base;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatBot.Clients.Core.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AboutViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public ICommand ClosePopupCommand => new Command(async () => await ClosePopupAsync());
        public ICommand TwitterNavigationCommand => new Command(TwitterNavigation);

        public ICommand GithubNavigationCommand => new Command(GithubNavigation);
        public ICommand WebNavigationCommand => new Command(WebNavigation);

        private async Task ClosePopupAsync()
        {
            await PopupNavigation.PopAllAsync(true);
        }

        private void GithubNavigation() {
            Device.OpenUri(new Uri("https://github.com/wilsonvargas"));
        }

        private void TwitterNavigation()
        {
            Device.OpenUri(new Uri("https://twitter.com/Wilson_VargasM"));
        }

        private void WebNavigation()
        {
            Device.OpenUri(new Uri("https://blog.wilsonvargas.com"));
        }
    }
}
