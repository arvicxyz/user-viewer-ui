using UIKit;
using XamApp.Core;
using XamApp.iOS.Dependencies;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: Dependency(typeof(StatusBar))]
namespace XamApp.iOS.Dependencies
{
    public class StatusBar : IStatusBarPlatformSpecific
    {
        public StatusBar()
        {
        }

        public void SetStatusBarColor(Color color, bool isLightTheme)
        {
            UIColor backgroundColor = color.ToUIColor();
            UINavigationBar.Appearance.BarTintColor = backgroundColor;

            UIColor textColor;
            if (isLightTheme)
            {
                textColor = UIColor.Black;
                UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.DarkContent, true);
            }
            else
            {
                textColor = UIColor.White;
                UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, true);
            }

            UINavigationBar.Appearance.TintColor = textColor;
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
            {
                TextColor = textColor
            });
        }
    }
}
