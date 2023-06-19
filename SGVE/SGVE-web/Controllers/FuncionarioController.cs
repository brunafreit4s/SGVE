using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGVE_web.Models;
using SGVE_web.Services.IServices;
using SGVE_web.Util;

namespace SGVE_web.Controllers
{    
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService ?? throw new ArgumentNullException(nameof(funcionarioService));
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");  /* Retorna access token para utilizar no swagger */
            var funcionarios = await _funcionarioService.FindAllFuncionarios(accessToken);

            foreach (var item in funcionarios)
            {
                if (!string.IsNullOrEmpty(item.Cpf)) item.Cpf = Convert.ToUInt64(item.Cpf).ToString(@"000\.000\.000\-00");
                if (!string.IsNullOrEmpty(item.Rg)) item.Rg = Convert.ToUInt64(item.Rg).ToString(@"00000000\-00");
            }

            return View(funcionarios);
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(FuncionarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");  
                var response = await _funcionarioService.CreateFuncionario(model, accessToken);

                if (response != null) return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<ActionResult> Update(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token"); 
            var funcionario = await _funcionarioService.FindByIdFuncionario(id, accessToken);

            if (funcionario != null)
            {
                if (!string.IsNullOrEmpty(funcionario.Cpf))         funcionario.Cpf = Convert.ToUInt64(funcionario.Cpf).ToString(@"000\.000\.000\-00");
                if (!string.IsNullOrEmpty(funcionario.Rg))          funcionario.Rg = Convert.ToUInt64(funcionario.Rg).ToString(@"00000000\-00");
                if (!string.IsNullOrEmpty(funcionario.Celular))     funcionario.Celular = Convert.ToUInt64(funcionario.Celular).ToString(@"(000) 00000-0000");
                if (!string.IsNullOrEmpty(funcionario.Telefone))    funcionario.Telefone = Convert.ToUInt64(funcionario.Telefone).ToString(@"(000) 0000-0000");

                return View(funcionario);
            }

            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Update(FuncionarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _funcionarioService.UpdateFuncionario(model, accessToken);
                if (response != null) return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");  
            var funcionario = await _funcionarioService.FindByIdFuncionario(id, accessToken);

            if (funcionario != null)
            {
                if (!string.IsNullOrEmpty(funcionario.Cpf)) funcionario.Cpf = Convert.ToUInt64(funcionario.Cpf).ToString(@"000\.000\.000\-00");
                if (!string.IsNullOrEmpty(funcionario.Rg)) funcionario.Rg = Convert.ToUInt64(funcionario.Rg).ToString(@"00000000\-00");
                if (!string.IsNullOrEmpty(funcionario.Celular)) funcionario.Celular = Convert.ToUInt64(funcionario.Celular).ToString(@"(000) 00000-0000");
                if (!string.IsNullOrEmpty(funcionario.Telefone)) funcionario.Telefone = Convert.ToUInt64(funcionario.Telefone).ToString(@"(000) 0000-0000");

                return View(funcionario);
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult> Delete(FuncionarioViewModel model)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token"); 
            var response = await _funcionarioService.DeleteFuncionario(model.Id, accessToken);
            if (response) return RedirectToAction(nameof(Index));

            return View(model);
        }
    }
}
