using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGVE_web.Models;
using SGVE_web.Services.IServices;
using SGVE_web.Util;

namespace SGVE_web.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutosService _ProdutosService;

        public ProdutosController(IProdutosService produtosService)
        {
            _ProdutosService = produtosService ?? throw new ArgumentNullException(nameof(produtosService));
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");  /* Retorna access token para utilizar no swagger */
            var Produtos = await _ProdutosService.FindAllProdutos(accessToken);
            return View(Produtos);
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(ProdutosViewModel model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");  /* Retorna access token para utilizar no swagger */
                var response = await _ProdutosService.CreateProdutos(model, accessToken);
                if (response != null) return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<ActionResult> Update(int Id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");  /* Retorna access token para utilizar no swagger */
            var Produtos = await _ProdutosService.FindByIdProdutos(Id, accessToken);

            if (Produtos != null) return View(Produtos);
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Update(ProdutosViewModel model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");  /* Retorna access token para utilizar no swagger */
                var response = await _ProdutosService.UpdateProdutos(model, accessToken);
                if (response != null) return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");  /* Retorna access token para utilizar no swagger */
            var Produtos = await _ProdutosService.FindByIdProdutos(id, accessToken);
            if (Produtos != null) return View(Produtos);
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult> Delete(ProdutosViewModel model)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");  /* Retorna access token para utilizar no swagger */
            var response = await _ProdutosService.DeleteProdutos(model.Id_Produto, accessToken);
            if (response) return RedirectToAction(nameof(Index));

            return View(model);
        }
    }
}
