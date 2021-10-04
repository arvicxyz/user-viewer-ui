using Xamarin.Forms;

namespace XamApp.ViewModels
{
    public interface IBaseViewModel
    {
        Page Page { get; set; }

        INavigation Navigation { get; set; }
    }
}
