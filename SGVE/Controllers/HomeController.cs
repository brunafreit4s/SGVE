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
        public async Task<JsonResult> ValidarAcesso(USUARIO vData)            
        {
            try
            {
                var httpClient = new HttpClient();
                var request = new HttpRequestMessage();
                var content = ToRequest(vData);
                var response = await httpClient.GetAsync(requestUri: _url + "api/Home/DadosUsuario"); ;

                var data = await response.Content.ReadAsStringAsync();

                //var teste = vData.LOGIN;
                RedirectToAction("Dashboard");

                return Json(data);


                /*
                 * 
                 * 
                    var httpClient = new HttpClient();
                    var request = new HttpRequestMessage();
                    var response = await httpClient.GetAsync(requestUri: "/Home/DadosUsuario");

                    var data = await response.Content.ReadAsStringAsync();

                    //var teste = vData.LOGIN;
                    RedirectToAction("Dashboard");

                    return Json(data);
                 * 
                 * 
                 */
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        private static StringContent ToRequest(object obj) {
            //Converte de json para stringContent
            var json = JsonConvert.SerializeObject(obj);
            var data = new StringContent(json, Encoding.UTF8, mediaType: "application/json");

            return data;
        }
    }
}
