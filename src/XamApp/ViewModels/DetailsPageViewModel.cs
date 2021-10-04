using System.Threading.Tasks;
using System.Windows.Input;
using XamApp.ViewModels.Commands;

namespace XamApp.ViewModels
{
    public class DetailsPageViewModel : BaseViewModel
    {
        #region Fields
        #endregion

        #region Constructors

        public DetailsPageViewModel()
        {
        }

        #endregion

        #region Public Methods

        public async Task Init()
        {
            await SetBusyAsync(async () =>
            {
                // Initialize page here
                await Task.Delay(100);
            }, 1000);
        }

        #endregion

        #region Private Methods

        private async Task BackNav()
        {
            await Navigation.PopAsync();
        }

        #endregion

        #region Commands

        private ICommand _backCommand;
        public ICommand BackCommand
        {
            get { return _backCommand ??= new DelegateCommand(async (obj) => await BackNav()); }
        }

        #endregion

        #region Properties
        #endregion
    }
}
