using ChatBot.Clients.Core.Services.Authentication;
using ChatBot.Clients.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatBot.Clients.Core.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authenticationService;

        public HomeViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        
        

        public ICommand SettingsCommand => new Command(async () => await AboutAsync());

        public ICommand GettingStartedCommand => new Command(async () => await GettingStartedAsync());

        public override async Task InitializeAsync(object navigationData)
        {
            try
            {
                IsBusy = true;
                var authenticatedUser = _authenticationService.AuthenticatedUser;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Home] Error: {ex}");
                await DialogService.ShowAlertAsync(Resources.ExceptionMessage, Resources.ExceptionTitle, Resources.DialogOk);
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async Task AboutAsync()
        {
            await NavigationService.NavigateToPopupAsync<AboutViewModel>(true);
        }
       
        private async Task GettingStartedAsync()
        {
            if (AppSettings.IsLogin)
            {
                await NavigationService.NavigateToAsync<ChatRoomViewModel>();
            }
        }       
    }
}
