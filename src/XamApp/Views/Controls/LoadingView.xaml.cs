using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamApp.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingView : ContentView
    {
        private const int LOADING_ENTER_DELAY = 250;
        private const int LOADING_EXIT_DELAY = 250;
        private const int ANIMATION_ENTER_SPEED = 150;
        private const int ANIMATION_EXIT_SPEED = 150;

        #region Bindable Properties

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text),
            returnType: typeof(string),
            declaringType: typeof(LoadingView),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty IsLoadingProperty = BindableProperty.Create(
            propertyName: nameof(IsLoading),
            returnType: typeof(bool),
            declaringType: typeof(LoadingView),
            defaultValue: false,
            defaultBindingMode: BindingMode.TwoWay);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        #endregion

        public LoadingView()
        {
            InitializeComponent();
            ResetDefaults();
        }

        protected override async void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == TextProperty.PropertyName)
            {
                LoadingLabel.Text = Text;
            }

            if (propertyName == IsLoadingProperty.PropertyName)
            {
                if (IsLoading)
                {
                    LoadingIndicator.IsRunning = IsLoading;
                    await Task.Delay(LOADING_ENTER_DELAY);
                    this.IsVisible = true;
                    await this.FadeTo(1, ANIMATION_ENTER_SPEED);
                }
                else
                {
                    await Task.Delay(LOADING_EXIT_DELAY);
                    await Task.WhenAll(
                        this.ScaleTo(0, ANIMATION_EXIT_SPEED),
                        this.FadeTo(0, ANIMATION_EXIT_SPEED)
                    );
                    this.IsVisible = false;
                    ResetDefaults();
                    LoadingIndicator.IsRunning = IsLoading;
                }
            }
        }

        private void ResetDefaults()
        {
            Opacity = 0;
            Scale = 1;
        }
    }
}
