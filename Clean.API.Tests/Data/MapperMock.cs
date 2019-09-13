using AutoMapper;
using Clean.Infrastructure.Mapping;

namespace Clean.API.Tests.Data
{
    public static class MapperMock
    {
        public static IMapper MapperProfileTest()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            }).CreateMapper();
        }
    }
}