using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SGVE_web.Models;
using SGVE_web.Services.IServices;
using System.Web.Http;

namespace SGVE_web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IProdutosService _produtosService;
        private readonly IFuncionarioService _funcionarioService;

        public DashboardController(IProdutosService produtosService, IFuncionarioService funcionarioService)
        {
            _produtosService = produtosService ?? throw new ArgumentNullException(nameof(produtosService));
            _funcionarioService = funcionarioService ?? throw new ArgumentNullException(nameof(funcionarioService));
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            if (accessToken == null) { return RedirectToAction("Index", "Home"); }

            Retorno retorno = new Retorno();

            retorno.Produtos = await _produtosService.FindAllProdutosChart(accessToken);
            retorno.Funcionario = await _funcionarioService.FindAllFuncionarios(accessToken);        

            return View(retorno);
        }
    }
}
