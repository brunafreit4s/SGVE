using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGVE_web.Models;
using SGVE_web.Services.IServices;

namespace SGVE_web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IProdutosService _produtosService;
        private readonly IFuncionarioService _funcionarioService;
        private readonly IVendasService _vendasService;

        public DashboardController(IProdutosService produtosService, IFuncionarioService funcionarioService, IVendasService vendasService)
        {
            _produtosService = produtosService ?? throw new ArgumentNullException(nameof(produtosService));
            _funcionarioService = funcionarioService ?? throw new ArgumentNullException(nameof(funcionarioService));
            _vendasService = vendasService ?? throw new ArgumentNullException(nameof(vendasService));
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            Retorno retorno = new Retorno();

            retorno.Produtos = await _produtosService.FindAllProdutosChart(accessToken);
            retorno.Vendas = await _vendasService.FindAllVendas(accessToken);

            return View(retorno);
        }
    }
}
