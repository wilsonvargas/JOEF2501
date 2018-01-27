using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChatBot.Clients.Core.ViewModels.Base
{
    public interface IHandleViewAppearing
    {
        Task OnViewAppearingAsync(VisualElement view);
    }
    public interface IHandleViewDisappearing
    {
        Task OnViewDisappearingAsync(VisualElement view);
    }
}
