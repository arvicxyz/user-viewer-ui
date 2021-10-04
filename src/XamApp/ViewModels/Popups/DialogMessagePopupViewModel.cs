using System.Threading.Tasks;
using System.Windows.Input;
using Rg.Plugins.Popup.Services;
using XamApp.ViewModels.Commands;
using XamApp.Views.Popups;

namespace XamApp.ViewModels
{
    public class DialogMessagePopupViewModel : BaseViewModel
    {
        #region Fields
        #endregion

        #region Constructors

        public DialogMessagePopupViewModel()
        {
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods

        private async Task Cancel(object obj)
        {
            if (obj == null || IsClosing)
                return;

            IsClosing = true;

            IsAccepted = false;
            await PopupNavigation.Instance.PopAsync();
            (obj as DialogMessagePopup)?.DialogClosedTaskCompletionSource.SetResult(false);
        }

        private async Task Accept(object obj)
        {
            if (obj == null || IsClosing)
                return;

            IsClosing = true;

            IsAccepted = true;
            await PopupNavigation.Instance.PopAsync();
            (obj as DialogMessagePopup)?.DialogClosedTaskCompletionSource.SetResult(true);
        }

        #endregion

        #region Commands

        private ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get { return _cancelCommand ??= new DelegateCommand(async (obj) => await Cancel(obj)); }
        }

        private ICommand _acceptCommand;
        public ICommand AcceptCommand
        {
            get { return _acceptCommand ??= new DelegateCommand(async (obj) => await Accept(obj)); }
        }

        #endregion

        #region Properties

        private string _titleText;
        public string TitleText
        {
            get => _titleText;
            set => SetProperty(ref _titleText, value, nameof(TitleText));
        }

        private string _messageText;
        public string MessageText
        {
            get => _messageText;
            set => SetProperty(ref _messageText, value, nameof(MessageText));
        }

        private string _cancelText;
        public string CancelText
        {
            get => _cancelText;
            set => SetProperty(ref _cancelText, value, nameof(CancelText));
        }

        private string _acceptText;
        public string AcceptText
        {
            get => _acceptText;
            set => SetProperty(ref _acceptText, value, nameof(AcceptText));
        }

        private bool? _isAccepted;
        public bool? IsAccepted
        {
            get => _isAccepted;
            set => SetProperty(ref _isAccepted, value, nameof(IsAccepted));
        }

        private bool _isClosing;
        public bool IsClosing
        {
            get => _isClosing;
            set => SetProperty(ref _isClosing, value, nameof(IsClosing));
        }

        #endregion
    }
}
