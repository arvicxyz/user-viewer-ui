namespace XamApp.Services.ApiClientServices
{
    public interface IApiService<T>
    {
        T Api { get; }
    }
}
