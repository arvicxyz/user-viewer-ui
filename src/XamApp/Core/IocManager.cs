using DryIoc;
using XamApp.Services;
using XamApp.Services.ApiClientServices;
using XamApp.Services.Interfaces;
using XamApp.ViewModels;

namespace XamApp.Core
{
    public static class IocManager
    {
        public static IContainer Container { get; private set; }

        public static void RegisterDependencies(IContainer container)
        {
            container.RegisterInstance(AutoMapperConfiguration.CreateMapper());

            container.Register(typeof(IApiService<>), typeof(ApiService<>));
            container.Register(typeof(IDataStoreService<>), typeof(DataStoreService<>));

            // Services
            container.Register<IMainPageService, MainPageService>();

            // View Models
            container.Register<MainPageViewModel>();
            container.Register<DetailsPageViewModel>();

            Container = container;
        }
    }
}
