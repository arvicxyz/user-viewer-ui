using Xamarin.Forms;

namespace XamApp.Core
{
    public interface IStatusBarPlatformSpecific
    {
        void SetStatusBarColor(Color color, bool isLightTheme);
    }
}
