using System.Windows.Input;
using XamApp.ViewModels.Commands;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;
using Xamarin.Forms.Xaml;

namespace XamApp.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToolbarView : PancakeView
    {
        #region Bindable Properties

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text),
            returnType: typeof(string),
            declaringType: typeof(ToolbarView),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty SubTextProperty = BindableProperty.Create(
            propertyName: nameof(SubText),
            returnType: typeof(string),
            declaringType: typeof(ToolbarView),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            propertyName: nameof(FontFamily),
            returnType: typeof(string),
            declaringType: typeof(ToolbarView),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            propertyName: nameof(FontSize),
            returnType: typeof(double),
            declaringType: typeof(ToolbarView),
            defaultValue: 0.0,
            defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            propertyName: nameof(TextColor),
            returnType: typeof(Color),
            declaringType: typeof(ToolbarView),
            defaultValue: Color.Default,
            defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty IconProperty = BindableProperty.Create(
            propertyName: nameof(Icon),
            returnType: typeof(string),
            declaringType: typeof(ToolbarView),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty IconFontProperty = BindableProperty.Create(
            propertyName: nameof(IconFont),
            returnType: typeof(string),
            declaringType: typeof(ToolbarView),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty IconSizeProperty = BindableProperty.Create(
            propertyName: nameof(IconSize),
            returnType: typeof(double),
            declaringType: typeof(ToolbarView),
            defaultValue: 0.0,
            defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty IconAlignmentProperty = BindableProperty.Create(
            propertyName: nameof(IconAlignment),
            returnType: typeof(TextAlignment),
            declaringType: typeof(ToolbarView),
            defaultValue: TextAlignment.Start,
            defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty IconPaddingProperty = BindableProperty.Create(
            propertyName: nameof(IconPadding),
            returnType: typeof(Thickness),
            declaringType: typeof(ToolbarView),
            defaultValue: new Thickness(0),
            defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty IconColorProperty = BindableProperty.Create(
            propertyName: nameof(IconColor),
            returnType: typeof(Color),
            declaringType: typeof(ToolbarView),
            defaultValue: Color.Default,
            defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty ToolbarItemTextProperty = BindableProperty.Create(
            propertyName: nameof(ToolbarItemText),
            returnType: typeof(string),
            declaringType: typeof(ToolbarView),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty BarBackgroundColorProperty = BindableProperty.Create(
            propertyName: nameof(BarBackgroundColor),
            returnType: typeof(Color),
            declaringType: typeof(ToolbarView),
            defaultValue: Color.Default,
            defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty HasIconProperty = BindableProperty.Create(
            propertyName: nameof(HasIcon),
            returnType: typeof(bool),
            declaringType: typeof(ToolbarView),
            defaultValue: false,
            defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty ShowShadowProperty = BindableProperty.Create(
            propertyName: nameof(ShowShadow),
            returnType: typeof(bool),
            declaringType: typeof(ToolbarView),
            defaultValue: false,
            defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            propertyName: nameof(Command),
            returnType: typeof(ICommand),
            declaringType: typeof(ToolbarView),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty ToolbarItemCommandProperty = BindableProperty.Create(
            propertyName: nameof(ToolbarItemCommand),
            returnType: typeof(ICommand),
            declaringType: typeof(ToolbarView),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string SubText
        {
            get { return (string)GetValue(SubTextProperty); }
            set { SetValue(SubTextProperty, value); }
        }

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

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

        public double IconSize
        {
            get { return (double)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        public TextAlignment IconAlignment
        {
            get { return (TextAlignment)GetValue(IconAlignmentProperty); }
            set { SetValue(IconAlignmentProperty, value); }
        }

        public Thickness IconPadding
        {
            get { return (Thickness)GetValue(IconPaddingProperty); }
            set { SetValue(IconPaddingProperty, value); }
        }

        public Color IconColor
        {
            get { return (Color)GetValue(IconColorProperty); }
            set { SetValue(IconColorProperty, value); }
        }

        public string ToolbarItemText
        {
            get { return (string)GetValue(ToolbarItemTextProperty); }
            set { SetValue(ToolbarItemTextProperty, value); }
        }

        public Color BarBackgroundColor
        {
            get { return (Color)GetValue(BarBackgroundColorProperty); }
            set { SetValue(BarBackgroundColorProperty, value); }
        }

        public bool HasIcon
        {
            get { return (bool)GetValue(HasIconProperty); }
            set { SetValue(HasIconProperty, value); }
        }

        public bool ShowShadow
        {
            get { return (bool)GetValue(ShowShadowProperty); }
            set { SetValue(ShowShadowProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public ICommand ToolbarItemCommand
        {
            get { return (ICommand)GetValue(ToolbarItemCommandProperty); }
            set { SetValue(ToolbarItemCommandProperty, value); }
        }

        #endregion

        public ToolbarView()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == TextProperty.PropertyName)
            {
                TitleLabel.Text = Text;
            }

            if (propertyName == SubTextProperty.PropertyName)
            {
                SubtitleLabel.Text = SubText;
                if (string.IsNullOrEmpty(SubtitleLabel.Text))
                    SubtitleLabel.IsVisible = false;
                else
                    SubtitleLabel.IsVisible = true;
            }

            if (propertyName == FontFamilyProperty.PropertyName)
            {
                TitleLabel.FontFamily = FontFamily;
            }

            if (propertyName == FontSizeProperty.PropertyName)
            {
                TitleLabel.FontSize = FontSize;
            }

            if (propertyName == TextColorProperty.PropertyName)
            {
                TitleLabel.TextColor = TextColor;
                SubtitleLabel.TextColor = TextColor;
                TextButton.TextColor = TextColor;
            }

            if (propertyName == IconProperty.PropertyName)
            {
                IconButton.Text = Icon;
            }

            if (propertyName == IconFontProperty.PropertyName)
            {
                IconButton.FontFamily = IconFont;
            }

            if (propertyName == IconSizeProperty.PropertyName)
            {
                IconButton.FontSize = IconSize;
            }

            if (propertyName == IconAlignmentProperty.PropertyName)
            {
                IconButton.HorizontalTextAlignment = IconAlignment;
            }

            if (propertyName == IconPaddingProperty.PropertyName)
            {
                IconButton.Margin = IconPadding;
            }

            if (propertyName == IconColorProperty.PropertyName)
            {
                IconButton.TextColor = IconColor;
            }

            if (propertyName == ToolbarItemTextProperty.PropertyName)
            {
                TextButton.Text = ToolbarItemText;
                TextButton.IsVisible = !string.IsNullOrEmpty(ToolbarItemText);
            }

            if (propertyName == BarBackgroundColorProperty.PropertyName)
            {
                BarView.BackgroundColor = BarBackgroundColor;
            }

            if (propertyName == HasIconProperty.PropertyName)
            {
                IconButton.IsVisible = HasIcon;
            }

            if (propertyName == ShowShadowProperty.PropertyName)
            {
                if (ShowShadow)
                    BarView.Style = (Style)App.Current.Resources["ToolbarShadowStyle"];
                else
                    BarView.Style = null;
            }
        }

        private ICommand _iconCommand;
        public ICommand IconCommand
        {
            get { return _iconCommand ??= new DelegateCommand((obj) => { Command.Execute(obj); }); }
        }

        private ICommand _buttonCommand;
        public ICommand ButtonCommand
        {
            get { return _buttonCommand ??= new DelegateCommand((obj) => { ToolbarItemCommand.Execute(obj); }); }
        }
    }
}
