using System.Collections.Generic;
using System.Threading.Tasks;

namespace XamApp.Services.Interfaces
{
    public interface IMainPageService
    {
        Task<List<Models.UserModel>> GetUsers();
    }
}
