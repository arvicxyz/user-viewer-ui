using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using AndroidX.AppCompat.App;

namespace XamApp.Droid.Activities
{
    [Activity(
        Icon = "@mipmap/icon",
        Label = "@string/app_name_string",
        Theme = "@style/Theme.Splash",
        MainLauncher = true,
        NoHistory = true,
        ScreenOrientation = ScreenOrientation.FullSensor,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation |
                               ConfigChanges.UiMode | ConfigChanges.ScreenLayout |
                               ConfigChanges.SmallestScreenSize)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetExitAction();
        }

        protected override void OnResume()
        {
            base.OnResume();

            // Launches the startup task
            StartApplication();
        }

        public override void OnBackPressed()
        {
            // Prevent the back button from canceling the startup process
        }

        private void StartApplication()
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        private static void SetExitAction()
        {
            App.ExitApplication = () =>
            {
                Process.KillProcess(Process.MyPid());
            };
        }
    }
}
