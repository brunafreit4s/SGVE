using AutoMapper;
using SGVE_api.Data.ValueObjects;
using SGVE_api.Models;

namespace SGVE_api.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            /* Configuração do VO */
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<FuncionarioVO, Funcionario>();
                config.CreateMap<Funcionario, FuncionarioVO>();
                config.CreateMap<ProdutosVO, Produtos>();
                config.CreateMap<Produtos, ProdutosVO>();
            });
            return mappingConfig;           
        }
    }
}
