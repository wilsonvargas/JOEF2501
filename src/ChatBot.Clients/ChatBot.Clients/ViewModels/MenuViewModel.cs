using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ChatBot.Clients.Core.Models;
using ChatBot.Clients.Core.Services.Authentication;
using ChatBot.Clients.Core.ViewModels.Base;
using Xamarin.Forms;

namespace ChatBot.Clients.Core.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        const string Skype = "Skype";
        const string FacebookMessenger = "Facebook Messenger";

        private ObservableCollection<Models.MenuItem> _menuItems;

        private readonly IAuthenticationService _authenticationService;

        public MenuViewModel(
            IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;

            MenuItems = new ObservableCollection<Models.MenuItem>();

            InitMenuItems();
        }

        public string UserName => AppSettings.User?.Name;

        public string UserAvatar => AppSettings.User?.AvatarUrl;

        public ObservableCollection<Models.MenuItem> MenuItems
        {
            get
            {
                return _menuItems;
            }
            set
            {
                _menuItems = value;
                OnPropertyChanged();
            }
        }

        public ICommand MenuItemSelectedCommand => new Command<Models.MenuItem>(OnSelectMenuItem);

       

        private void InitMenuItems()
        {
            MenuItems.Add(new Models.MenuItem
            {
                Title = "Home",
                MenuItemType = MenuItemType.Home,
                ViewModelType = typeof(MainViewModel),
                IsEnabled = true
            });

            MenuItems.Add(new Models.MenuItem
            {
                Title = "My Profile",
                MenuItemType = MenuItemType.Profile,
                ViewModelType = typeof(ProfileViewModel),
                IsEnabled = true
            });

            MenuItems.Add(new Models.MenuItem
            {
                Title = "Logout",
                MenuItemType = MenuItemType.Logout,
                ViewModelType = typeof(LoginViewModel),
                IsEnabled = true,
                AfterNavigationAction = RemoveUserCredentials
            });
        }

        private async void OnSelectMenuItem(Models.MenuItem item)
        {
            if (item.IsEnabled && item.ViewModelType != null)
            {
                item.AfterNavigationAction?.Invoke();
                await NavigationService.NavigateToAsync(item.ViewModelType, item);
            }
        }

        private Task RemoveUserCredentials()
        {
            AppSettings.IsLogin = false;
            SetMenuItemStatus(MenuItemType.Profile, false);
            SetMenuItemStatus(MenuItemType.Logout, false);
            return _authenticationService.LogoutAsync();
        }

        private void SetMenuItemStatus(MenuItemType type, bool enabled)
        {
            Models.MenuItem menuItem = MenuItems.FirstOrDefault(m => m.MenuItemType == type);

            if (menuItem != null)
            {
                menuItem.IsEnabled = enabled;
            }
        }
    }
}
