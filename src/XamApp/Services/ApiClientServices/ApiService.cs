using Refit;
using XamApp.Constants;

namespace XamApp.Services.ApiClientServices
{
    public class ApiService<T> : IApiService<T>
    {
        public T Api { get; }

        public ApiService()
        {
            Api = RestService.For<T>(AppConstants.WebApiBaseUrl);
        }
    }
}
