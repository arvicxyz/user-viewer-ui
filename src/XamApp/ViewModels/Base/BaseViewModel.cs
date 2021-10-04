using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamApp.ViewModels
{
    public class BaseViewModel : BindableBase, IBaseViewModel
    {
        private const string DEFAULT_LOADING_MESSAGE = "Loading...";

        public Page Page { get; set; }
        public INavigation Navigation { get; set; }

        public BaseViewModel()
        {
        }

        public async Task SetBusyAsync(Func<Task> func, int millisecDelay = 0, string loadingMessage = null)
        {
            if (!string.IsNullOrEmpty(loadingMessage))
                LoadingMessage = loadingMessage;
            else
                LoadingMessage = DEFAULT_LOADING_MESSAGE;

            IsBusy = true;

            try
            {
                await func();
                await Task.Delay(millisecDelay);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task SetInputBusyAsync(Func<Task> func)
        {
            if (IsInputBusy)
                return;

            IsInputBusy = true;

            try
            {
                await func();
            }
            finally
            {
                IsInputBusy = false;
            }
        }

        private string _pageTitle;
        public string PageTitle
        {
            get => _pageTitle;
            set => SetProperty(ref _pageTitle, value, nameof(PageTitle));
        }

        private string _pageSubtitle;
        public string PageSubtitle
        {
            get => _pageSubtitle;
            set => SetProperty(ref _pageSubtitle, value, nameof(PageSubtitle));
        }

        private string _loadingMessage;
        public string LoadingMessage
        {
            get => _loadingMessage;
            set => SetProperty(ref _loadingMessage, value, nameof(LoadingMessage));
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value, nameof(IsBusy));
        }

        private bool _isInputBusy;
        public bool IsInputBusy
        {
            get => _isInputBusy;
            set => SetProperty(ref _isInputBusy, value, nameof(IsInputBusy));
        }
    }
}
