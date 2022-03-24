using System;
using System.Collections.Generic;
using System.Linq;
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

        public IActionResult Dashboard()
        {
            ViewData["Message"] = "Seja bem vindo(a) ";

            return View();
        }

        [HttpPost]
        public async Task<JsonResult> ValidarAcesso(Usuario vData)
        {
            try
            {
                Retorno oRetorno = new Retorno();
                var httpClient = new HttpClient();
                var request = new HttpRequestMessage();
                var strContent = ToRequest(vData);
                var response = await httpClient.PostAsync(requestUri: _url + "api/Home/DadosUsuario/", strContent);

                if (response.IsSuccessStatusCode)
                {
                    string strRetorno = await response.Content.ReadAsStringAsync();
                    var usuario = JsonConvert.DeserializeObject<Usuario>(strRetorno);

                    oRetorno.tbUsuario.Add(usuario);
                }
                else
                {
                    ERRO objErro = new ERRO();
                    objErro.strErro = "E-mail ou Senha incorreta. Verifique os dados informados!";
                    oRetorno.tbERRO.Add(objErro);
                }

                return Json(oRetorno);
            }
            catch (Exception ex)
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
