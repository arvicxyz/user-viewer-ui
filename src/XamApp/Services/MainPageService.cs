using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using XamApp.Core;
using XamApp.Models;
using XamApp.Services.ApiClientServices;
using XamApp.Services.Interfaces;

namespace XamApp.Services
{
    public class MainPageService : BaseService, IMainPageService
    {
        private readonly IApiService<ITrefleService> _trefleService;
        private readonly IMapper _mapper;

        public MainPageService(
            IApiService<ITrefleService> trefleService,
            IMapper mapper)
        {
            _trefleService = trefleService;
            _mapper = mapper;
        }

        public async Task<List<UserModel>> GetUsers()
        {
            var response = await InvokeWithPolicyAsync(() => _trefleService.Api.GetUsers());

            if (response.FinalException != null)
            {
                ExceptionHandler.LogException(response.FinalException);
                throw response.FinalException;
            }

            return _mapper.Map<List<Models.UserModel>>(response.Result);
        }
    }
}
