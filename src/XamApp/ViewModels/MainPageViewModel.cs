using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using XamApp.Constants;
using XamApp.Models;
using XamApp.Services.Interfaces;
using XamApp.Utilities;
using XamApp.ViewModels.Commands;
using XamApp.Views;
using Xamarin.Forms;

namespace XamApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Fields

        private readonly IMainPageService _mainPageService;

        #endregion

        #region Constructors

        public MainPageViewModel(IMainPageService mainPageService)
        {
            _mainPageService = mainPageService;

            PageTitle = (string)App.Current.Resources["AppNameString"];
        }

        #endregion

        #region Public Methods

        public async Task Init()
        {
            if (GroupedData != null && GroupedData.Count > 0)
                return;

            await SetBusyAsync(async () =>
            {
                bool isOnline = AppGlobal.IsOnline;
                if (isOnline)
                {
                    var users = await _mainPageService.GetUsers();
                    GroupedData = users.OrderBy(x => x.Name)
                        .GroupBy(x => x.Name[0].ToString().ToUpper())
                        .Select(x => new ObservableGroupCollection<string, UserModel>(x))
                        .ToList();
                }
                else
                {
                    await Page.DisplayAlert("Offline", "You are currently not connected to the internet. Please connect then try again.", "OK");
                }
            });
        }

        #endregion

        #region Private Methods

        private async Task SelectItem(object obj)
        {
            await SetInputBusyAsync(async () =>
            {
                if (obj == null)
                    return;

                var isOpen = await DialogPopup.Show("Proceed?", "Do you want to open this item?", "Yes", "No");
                if (!isOpen)
                {
                    IsInputBusy = false;
                    return;
                }

                var args = (ItemTappedEventArgs)obj;
                await SetBusyAsync(async () =>
                {
                    var page = new DetailsPage();
                    var selectedItem = (UserModel)args.Item;
                    var viewModel = (DetailsPageViewModel)page.BindingContext;
                    viewModel.PageTitle = $"{selectedItem.Name}";
                    await Navigation.PushAsync(page);
                });
            });
        }

        #endregion

        #region Commands

        private ICommand _selectItemCommand;
        public ICommand SelectItemCommand
        {
            get { return _selectItemCommand ??= new DelegateCommand(async (obj) => await SelectItem(obj)); }
        }

        #endregion

        #region Properties

        private List<ObservableGroupCollection<string, UserModel>> _groupedData;
        public List<ObservableGroupCollection<string, UserModel>> GroupedData
        {
            get => _groupedData;
            set => SetProperty(ref _groupedData, value, nameof(GroupedData));
        }

        #endregion
    }
}
