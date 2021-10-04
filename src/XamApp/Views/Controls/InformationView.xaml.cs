using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamApp.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InformationView : ContentView
    {
        #region Bindable Properties

        public static readonly BindableProperty IconProperty = BindableProperty.Create(
            propertyName: nameof(Icon),
            returnType: typeof(string),
            declaringType: typeof(InformationView),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty IconFontProperty = BindableProperty.Create(
            propertyName: nameof(IconFont),
            returnType: typeof(string),
            declaringType: typeof(InformationView),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text),
            returnType: typeof(string),
            declaringType: typeof(InformationView),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay);

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public string IconFont
        {
            get { return (string)GetValue(IconFontProperty); }
            set { SetValue(IconFontProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        #endregion

        public InformationView()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == IconProperty.PropertyName)
            {
                InfoImage.Text = Icon;
            }

            if (propertyName == IconFontProperty.PropertyName)
            {
                InfoImage.FontFamily = IconFont;
            }

            if (propertyName == TextProperty.PropertyName)
            {
                InfoLabel.Text = Text;
            }
        }
    }
}
