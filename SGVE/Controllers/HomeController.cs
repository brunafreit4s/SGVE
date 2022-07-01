using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGVE.Models;

namespace SGVE.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _url = "https://localhost:44328/";

        public IActionResult Index()
        {
            ViewBag.Title = "SGVEC - Área de Acesso";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> Dashboard(int COD_FUNC, string NOME_FUNC)
        {        
            ViewBag.Lista_Produtos  = await Get_ProtudosEstoque();
            ViewBag.Lista_Vendas    = await Get_Vendas();
            ViewBag.NomeLogado      = NOME_FUNC;
            ViewBag.Codigo          = COD_FUNC;

            return View();
        }

        public async Task<List<Produtos>> Get_ProtudosEstoque()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(requestUri: _url + "api/Home/ProdutosEstoque/");
            var oRetorno = new List<Produtos>();

            if (response.IsSuccessStatusCode)
            {
                string strRetorno = await response.Content.ReadAsStringAsync();
                 oRetorno = JsonConvert.DeserializeObject<List<Produtos>>(strRetorno);
            }

            return oRetorno;
        }

        public async Task<List<Vendas>> Get_Vendas()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(requestUri: _url + "api/Home/Data_Total_Vendas/");
            var oRetorno = new List<Vendas>();

            if (response.IsSuccessStatusCode)
            {
                string strRetorno = await response.Content.ReadAsStringAsync();
                oRetorno = JsonConvert.DeserializeObject<List<Vendas>>(strRetorno);
            }

            return oRetorno;
        }

        [HttpPost]
        public async Task<IActionResult> ValidarAcesso(Usuario vData)
        {
            try
            {
                if(string.IsNullOrEmpty(vData.EMAIL_FUNC) || string.IsNullOrEmpty(vData.SENHA_FUNC)) { return RedirectToAction("Index", "Home"); }

                Retorno oRetorno = new Retorno();
                var httpClient = new HttpClient();
                var request = new HttpRequestMessage();
                var strContent = ToRequest(vData);
                var response = await httpClient.PostAsync(requestUri: _url + "api/Home/DadosUsuario/", strContent);

                if (response.IsSuccessStatusCode)
                {
                    string strRetorno = await response.Content.ReadAsStringAsync();
                    oRetorno.tbUsuario = JsonConvert.DeserializeObject<List<Usuario>>(strRetorno);
                }
                else
                {
                    ERRO objErro = new ERRO();
                    objErro.strErro = "E-mail ou Senha inválidos. Verifique os dados digitados!";
                    oRetorno.tbERRO.Add(objErro);
                }

                return Json(oRetorno);
            }
            catch
            {
                throw;
            }
        }

        private static StringContent ToRequest(object obj)
        {
            //Converte de json para stringContent
            var json = JsonConvert.SerializeObject(obj);
            var data = new StringContent(json, Encoding.UTF8, mediaType: "application/json");

            return data;
        }
    }
}
