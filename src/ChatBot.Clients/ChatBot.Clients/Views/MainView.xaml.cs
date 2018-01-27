using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatBot.Clients.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : MasterDetailPage
    {
        public MainView()
        {
            InitializeComponent();
        }
    }
}