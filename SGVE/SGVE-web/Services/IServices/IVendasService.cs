using SGVE_web.Models;

namespace SGVE_web.Services.IServices
{
    public interface IVendasService
    {
        Task<IEnumerable<VendasViewModel>> FindAllVendas(string token);
    }
}
