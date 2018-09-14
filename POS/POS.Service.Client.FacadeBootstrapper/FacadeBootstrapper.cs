using AutoMapper;
using POS.Core.Models;
using POS.Service.Client.DataContracts;

namespace POS.Service.FacadeBootstrapper
{
    public static class FacadeBootstrapper
    {
        private static IMapper _mapper;
        private static bool _IsInitialized = false;
        public static void Initialize()
        {
            //guarantee this is only initialized once - otherwise the AfterMap calls happen multiple times
            if (_IsInitialized)
                return;

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductDTO>();
            });
            _mapper = config.CreateMapper();

            _IsInitialized = true;

          
        }


        }
}
