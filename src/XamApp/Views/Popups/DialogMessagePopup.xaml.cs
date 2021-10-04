using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using XamApp.ViewModels;
using Xamarin.Forms.Xaml;

namespace XamApp.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DialogMessagePopup : PopupPage
    {
        private DialogMessagePopupViewModel _viewModel;

        public Task<bool> DialogClosedTask { get { return DialogClosedTaskCompletionSource.Task; } }
        public TaskCompletionSource<bool> DialogClosedTaskCompletionSource { get; set; }

        public DialogMessagePopup()
        {
            InitializeComponent();

            _viewModel = (DialogMessagePopupViewModel)BindingContext;

            DialogClosedTaskCompletionSource = new TaskCompletionSource<bool>();
        }

        protected override void OnDisappearing()
        {
            if (_viewModel.IsAccepted == null)
                DialogClosedTaskCompletionSource.SetResult(false);
            _viewModel.IsClosing = false;
        }
    }
}
