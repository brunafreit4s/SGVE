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
                config.CreateMap<ProdutosCarrinhoVO, Produtos>().ReverseMap();
                config.CreateMap<VendaVO, Venda>().ReverseMap();
                config.CreateMap<Venda_x_ProdutoVO, Venda_x_Produto>().ReverseMap();
                config.CreateMap<CarrinhoVO, Carrinho>().ReverseMap();
            });
            return mappingConfig;           
        }
    }
}
