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
                if (!string.IsNullOrEmpty(item.Cpf)) item.Cpf           = Convert.ToUInt64(item.Cpf.Replace(".", "").Replace("-", "").Replace(" ", "")).ToString(@"000\.000\.000\-00");
                if (!string.IsNullOrEmpty(item.Rg)) item.Rg             = Convert.ToUInt64(item.Rg.Replace(".", "").Replace("-", "").Replace(" ", "")).ToString(@"00000000\-00");
                if (!string.IsNullOrEmpty(item.Celular)) item.Celular   = Convert.ToUInt64(item.Celular.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "")).ToString(@"(00) 00000-0000");
                if (!string.IsNullOrEmpty(item.Telefone)) item.Telefone = Convert.ToUInt64(item.Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "")).ToString(@"(00) 0000-0000");
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

                model.Cpf       = model.Cpf.Replace(".", "").Replace("-", "").Trim();
                model.Rg        = model.Rg.Replace(".", "").Replace("-", "").Trim();
                model.Celular   = model.Celular.Replace("(", "").Replace(")", "").Replace("-", "").Trim();
                model.Telefone  = model.Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Trim();

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
                if (!string.IsNullOrEmpty(funcionario.Cpf)) funcionario.Cpf           = Convert.ToUInt64(funcionario.Cpf.Replace(".", "").Replace("-", "").Replace(" ", "")).ToString(@"000\.000\.000\-00");
                if (!string.IsNullOrEmpty(funcionario.Rg)) funcionario.Rg             = Convert.ToUInt64(funcionario.Rg.Replace(".", "").Replace("-", "").Replace(" ", "")).ToString(@"00000000\-00");
                if (!string.IsNullOrEmpty(funcionario.Celular)) funcionario.Celular   = Convert.ToUInt64(funcionario.Celular.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "")).ToString(@"(00) 00000-0000");
                if (!string.IsNullOrEmpty(funcionario.Telefone)) funcionario.Telefone = Convert.ToUInt64(funcionario.Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "")).ToString(@"(00) 0000-0000");

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
                model.Cpf       = model.Cpf.Replace(".", "").Replace("-", "").Replace(" ", "");
                model.Rg        = model.Rg.Replace(".", "").Replace("-", "").Replace(" ", "");
                model.Celular   = model.Celular.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                model.Telefone  = model.Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

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
                if (!string.IsNullOrEmpty(funcionario.Cpf)) funcionario.Cpf           = Convert.ToUInt64(funcionario.Cpf.Replace(".", "").Replace("-", "").Replace(" ", "")).ToString(@"000\.000\.000\-00");
                if (!string.IsNullOrEmpty(funcionario.Rg)) funcionario.Rg             = Convert.ToUInt64(funcionario.Rg.Replace(".", "").Replace("-", "").Replace(" ", "")).ToString(@"00000000\-00");
                if (!string.IsNullOrEmpty(funcionario.Celular)) funcionario.Celular   = Convert.ToUInt64(funcionario.Celular.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "")).ToString(@"(00) 00000-0000");
                if (!string.IsNullOrEmpty(funcionario.Telefone)) funcionario.Telefone = Convert.ToUInt64(funcionario.Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "")).ToString(@"(00) 0000-0000");

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
