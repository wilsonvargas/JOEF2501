using ChatBot.Clients.Core.Services.Authentication;
using ChatBot.Clients.Core.Validations;
using ChatBot.Clients.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatBot.Clients.Core.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authenticationService;

        private ValidatableObject<string> _userName;
        private ValidatableObject<string> _password;

        public LoginViewModel(
            IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;

            _userName = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();

            AddValidations();
        }

        public ValidatableObject<string> UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public ValidatableObject<string> Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public ICommand SignInCommand => new Command(async () => await SignInAsync());

        public ICommand MicrosoftSignInCommand => new Command(async () => await FacebookSignInAsync());

        public ICommand SettingsCommand => new Command(async () => await NavigateToSettingsAsync(null));

        private async Task SignInAsync()
        {
            try
            {
                IsBusy = true;

                bool isValid = Validate();
                if (isValid)
                {
                    bool succeeded = await _authenticationService.LoginAsync(UserName.Value, Password.Value);
                    if (succeeded)
                    {
                        await NavigationService.NavigateToAsync<MainViewModel>();
                    }
                    else
                    {
                        await DialogService.ShowAlertAsync("Username or password not valid, try again", "Error", "Ok");
                    }
                }
                else
                {
                    await DialogService.ShowAlertAsync("Enter a valid value", "Error", "Ok");
                }
                
                
            }
            catch (Exception)
            {
                await DialogService.ShowAlertAsync("An error ocurred, try again", "Error", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
            
        }

        private async Task FacebookSignInAsync()
        {
            try
            {
                IsBusy = true;

                bool succeeded = await _authenticationService.LoginWithFacebookAsync();

                if (succeeded)
                {
                   await NavigationService.NavigateToAsync<MainViewModel>();
                }
            }
            catch (Exception)
            {
                await DialogService.ShowAlertAsync("An error ocurred, try again", "Error", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void AddValidations()
        {
            _userName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Username should not be empty" });
            _userName.Validations.Add(new EmailRule());
            _password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password should not be empty" });
        }

        private bool Validate()
        {
            bool isValidUser = _userName.Validate();
            bool isValidPassword = _password.Validate();

            return isValidUser && isValidPassword;
        }        

        private async Task NavigateToSettingsAsync(object obj)
        {
            //await NavigationService.NavigateToAsync(typeof(SettingsViewModel<RemoteSettings>));
        }
    }
}
