using Android.OS;
using Android.Views;
using XamApp.Core;
using XamApp.Droid.Dependencies;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Dependency(typeof(StatusBar))]
namespace XamApp.Droid.Dependencies
{
    public class StatusBar : IStatusBarPlatformSpecific
    {
        public StatusBar()
        {
        }

        public void SetStatusBarColor(Color color, bool isLightTheme)
        {
            var window = Xamarin.Essentials.Platform.CurrentActivity.Window;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                var androidColor = color.ToAndroid();
                window.SetStatusBarColor(androidColor);
            }

            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                SystemUiFlags systemUiVisibility = (SystemUiFlags)window.DecorView.SystemUiVisibility;

                if (isLightTheme)
                    systemUiVisibility |= SystemUiFlags.LightStatusBar;
                else
                    systemUiVisibility &= ~SystemUiFlags.LightStatusBar;

                window.DecorView.SystemUiVisibility = (StatusBarVisibility)systemUiVisibility;
            }
        }
    }
}
