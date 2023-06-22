using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGVE_web.Models;
using SGVE_web.Services.IServices;

namespace SGVE_web.Controllers
{
    public class VendasController : Controller
    {
        private readonly ILogger<VendasController> _logger;
        private readonly IProdutosService _ProdutosService;
        private readonly ICarrinhoService _CarrinhoService;

        public VendasController(IProdutosService produtosService, ICarrinhoService carrinhoService)
        {
            _ProdutosService = produtosService;
            _CarrinhoService = carrinhoService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");  /* Retorna access token para utilizar no swagger */
            var Produtos = await _ProdutosService.FindAllProdutos(accessToken);
            return View(Produtos);
        }

        [Authorize]
        public async Task<IActionResult> Vendas(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");  /* Retorna access token para utilizar no swagger */
            var Produto = await _ProdutosService.FindByIdProdutos(id, accessToken);
            return View(Produto);
        }

        [HttpPost]
        [ActionName("Vendas")]
        [Authorize]
        public async Task<ActionResult> VendasPost(ProdutosViewModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");  /* Retorna access token para utilizar no swagger */

            CarrinhoViewModel carrinho = new()
            {
                venda = new VendaViewModel()
                {
                    UserId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value
                }
            };

            Venda_x_ProdutoViewModel vendaxproduto = new Venda_x_ProdutoViewModel()
            {
                Count = model.Count,
                Id_Produto = model.Id_Produto,
                Produto = await _ProdutosService.FindByIdProdutos(model.Id_Produto, token),
            };

            List<Venda_x_ProdutoViewModel> ListVenda = new List<Venda_x_ProdutoViewModel>();
            ListVenda.Add(vendaxproduto);
            carrinho.venda_x_produto = ListVenda;

            var response = await _CarrinhoService.AddItemToCarrinho(carrinho, token);

            if (response != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(ListVenda);
        }
    }
}
