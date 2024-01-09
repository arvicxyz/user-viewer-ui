using System;
using System.Threading.Tasks;
using DryIoc;
using XamApp.Constants;
using XamApp.Core;
using XamApp.Localization;
using XamApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamApp
{
    public partial class App : Application
    {
        public static float ScreenWidth { get; set; }
        public static float ScreenHeight { get; set; }
        public static double StatusBarHeight { get; set; }

        public static Action ExitApplication;

        public App()
        {
            InitializeComponent();

            var config = Rules.Default;
            if (Device.RuntimePlatform == Device.iOS)
                config = config.WithTrackingDisposableTransients();

            IContainer Container = new Container(config);
            IocManager.RegisterDependencies(Container);

            OnInitialized();
        }

        protected override async void OnStart()
        {
            base.OnStart();

            SetInitializeScreen();

            // TODO: Put anything that needs to load for iOS and Android here
            await Task.Delay(AppConstants.InitialAppLoading);

            var page = new MainPage();
            MainPage = new NavigationPage(page)
            {
                BarTextColor = Color.White,
                BarBackgroundColor = AppGlobal.ToolbarColor
            };

            Device.BeginInvokeOnMainThread(() =>
            {
                var color = AppGlobal.ToolbarColor;
                var statusbar = DependencyService.Get<IStatusBarPlatformSpecific>();
                statusbar.SetStatusBarColor(color, false);
            });

            OnResume();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void OnInitialized()
        {
            Application.Current.UserAppTheme = OSAppTheme.Light;
            SetStatusBarHeight();
        }

        private void SetStatusBarHeight()
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                if (StatusBarHeight <= 0)
                {
                    if (Device.Idiom == TargetIdiom.Tablet)
                    {
                        // iPad
                        StatusBarHeight = 24;
                    }
                    else if (Device.Idiom == TargetIdiom.Phone)
                    {
                        // iPhone
                        if (DeviceInfo.Model == "iPhone 12" ||
                            DeviceInfo.Model == "iPhone 12 Pro" ||
                            DeviceInfo.Model == "iPhone 12 Pro Max" ||
                            DeviceInfo.Model == "iPhone 11" ||
                            DeviceInfo.Model == "iPhone 11 Pro" ||
                            DeviceInfo.Model == "iPhone 11 Pro Max" ||
                            DeviceInfo.Model == "iPhone X" ||
                            DeviceInfo.Model == "iPhone XR" ||
                            DeviceInfo.Model == "iPhone XS" ||
                            DeviceInfo.Model == "iPhone XS Max")
                        {
                            StatusBarHeight = 44;
                        }
                        else
                        {
                            StatusBarHeight = 20;
                        }
                    }
                }
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                if (Device.Idiom == TargetIdiom.Tablet)
                {
                    // Android Tablet
                    StatusBarHeight = 0;
                }
                else if (Device.Idiom == TargetIdiom.Phone)
                {
                    // Android Phone
                    StatusBarHeight = 0;
                }
            }
        }

        private void SetInitializeScreen()
        {
            var loadingSize = (OnPlatform<double>)Current.Resources["ActivityIndicatorSize"];
            var loadingScale = (OnPlatform<double>)Current.Resources["ActivityIndicatorScale"];
            var fontFamily = (OnPlatform<string>)Current.Resources["RegularFontFamily"];
            var fontSize = (OnPlatform<double>)Current.Resources["TitleFontSize"];
            var loadingColor = (Color)Current.Resources["PrimaryTextColor"];
            var backgroundColor = Color.White;

            Device.BeginInvokeOnMainThread(() =>
            {
                var statusbar = DependencyService.Get<IStatusBarPlatformSpecific>();
                statusbar.SetStatusBarColor(backgroundColor, true);
            });
            MainPage = new ContentPage
            {
                BackgroundColor = backgroundColor,
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new ActivityIndicator
                        {
                            WidthRequest = loadingSize,
                            HeightRequest = loadingSize,
                            Scale = loadingScale,
                            Color = loadingColor,
                            IsRunning = true
                        },
                        new Label
                        {
                            Text = "initializing".Translate(),
                            VerticalTextAlignment = TextAlignment.Center,
                            HorizontalTextAlignment = TextAlignment.Center,
                            FontFamily = fontFamily,
                            FontSize = fontSize,
                            TextColor = loadingColor
                        }
                    }
                }
            };
        }
    }
}
