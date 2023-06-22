using AutoMapper;
using SGVE.Cart.Data.ValueObjects;
using SGVE.Cart.Models;

namespace SGVE.Cart.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            /* Configuração do VO */
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<ProdutosVO, Produtos>().ReverseMap();
                config.CreateMap<CartHeaderVO, CartHeader>().ReverseMap();
                config.CreateMap<CartDetailVO, CartDetail>().ReverseMap();
                config.CreateMap<CartVO, Models.Cart>().ReverseMap();
            });
            return mappingConfig;           
        }
    }
}
