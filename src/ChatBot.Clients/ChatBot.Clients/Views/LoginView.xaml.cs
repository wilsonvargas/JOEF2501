using ChatBot.Clients.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatBot.Clients.Core.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginView : ContentPage
	{
        private object Parameter { get; set; }
        public LoginView ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            try
            {
                InitializeComponent();
            }
            catch (Exception ww)
            {

                throw;
            }
            
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();

            StatusBarHelper.Instance.MakeTranslucentStatusBar(true);
        }
    }
}