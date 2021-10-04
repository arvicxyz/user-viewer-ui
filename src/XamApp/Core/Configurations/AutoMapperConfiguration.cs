using AutoMapper;

namespace XamApp.Core
{
    public static class AutoMapperConfiguration
    {
        public static IMapper CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Models.Dtos.UserModel, Models.UserModel>();
            });

            return mapperConfiguration.CreateMapper();
        }
    }
}
