using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;
using Xamarin.Forms.Xaml;

namespace XamApp.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HotcakeView : PancakeView
    {
        private const int CLICK_DELAY = 100;

        #region Bindable Properties

        public static readonly BindableProperty SelectedColorProperty = BindableProperty.Create(
            propertyName: nameof(SelectedColor),
            returnType: typeof(Color),
            declaringType: typeof(HotcakeView),
            defaultValue: GetDefaultSelectedColor(),
            defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            propertyName: nameof(Command),
            returnType: typeof(ICommand),
            declaringType: typeof(HotcakeView),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
            propertyName: nameof(CommandParameter),
            returnType: typeof(object),
            declaringType: typeof(HotcakeView),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay);

        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        #endregion

        public HotcakeView()
        {
            InitializeComponent();
        }

        public void Execute(ICommand command, object parameter)
        {
            if (command == null) return;
            if (command.CanExecute(null))
            {
                command.Execute(parameter);
            }
        }

        private async void TapGestureRecognizerTapped(object sender, EventArgs e)
        {
            var view = sender as PancakeView;
            if (view != null)
            {
                VisualStateManager.GoToState(view, "Selected");
                await Task.Delay(CLICK_DELAY);
                VisualStateManager.GoToState(view, "Unselected");
            }

            OnTap.Execute(null);
        }

        private static Color GetDefaultSelectedColor()
        {
            return (Color)App.Current.Resources["SelectorColor"];
        }

        public Command OnTap => new Command(() => Execute(Command, CommandParameter));
    }
}
