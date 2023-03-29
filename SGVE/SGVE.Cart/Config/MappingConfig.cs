using AutoMapper;
//using SGVE.Cart.Data.ValueObjects;
using SGVE.Cart.Models;

namespace SGVE.Cart.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            /* Configuração do VO */
            var mappingConfig = new MapperConfiguration(config => {
                //config.CreateMap<FuncionarioVO, Funcionario>();
                //config.CreateMap<Funcionario, FuncionarioVO>();
                //config.CreateMap<ProdutosVO, Produtos>();
                //config.CreateMap<Produtos, ProdutosVO>();
            });
            return mappingConfig;           
        }
    }
}
