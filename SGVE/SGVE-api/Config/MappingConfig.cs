using AutoMapper;
using SGVE_api.Data.ValueObjects;
using SGVE_models.Models;

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
            });
            return mappingConfig;
        }
    }
}
