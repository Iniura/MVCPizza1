using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCPizza1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MVCPizza1.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace MVCPizza1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {


           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public int Add(int number1, int number2)
        {
            //OrdenesController oc = new OrdenesController();

            //var result = oc.GetOrdenes();

            return number1 + number2;
            
        }

        [HttpPost]
        public async Task<JsonResult> TraerOrdenes()
        {

            var baseUrl = HttpContext.Request.Host.ToUriComponent();

            List<Orden> ordenList = new List<Orden>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();
                using (var response = await httpClient.GetAsync("https://" + baseUrl + "/api/Ordenes"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ordenList = JsonConvert.DeserializeObject<List<Orden>>(apiResponse);
                }
            }

            List<OrdenView> ordenVList = new List<OrdenView>();
            foreach (var or in ordenList) {

                OrdenView ov = new OrdenView();
                ov.Id = or.Id;
                ov.TextoOrden = or.TextoOrden;
                ov.NombreTamano = Enum.GetName(typeof(TipoTamano), or.TipoTamano);
                ov.NombreMasa = Enum.GetName(typeof(TipoMasa), or.TipoMasa);
                ov.Ingredientes = or.Ingredientes;

                ordenVList.Add(ov);

            }

            return Json(ordenVList);
            //return JsonConvert.SerializeObject();
            //return Json(ordenList, new JsonSerializerSettings
            //{
            //    Formatting = Formatting.Indented,
            //});
        }





        [HttpPost]
        public async Task<JsonResult> SubirOrden(string TextoOrden, int TipoTamano, int TipoMasa, string ingredientes)
        {
            try
            {
                var baseUrl = HttpContext.Request.Host.ToUriComponent();

                Orden orden = new Orden() { 
                    TextoOrden = TextoOrden,
                    TipoTamano = TipoTamano,
                    TipoMasa = TipoMasa,
                    Ingredientes = ingredientes
                };


                //BaseURI = ConfigurationManager.AppSettings["WebApiUri"];
                using (var httpClient = new HttpClient())
                {
                    //client.BaseAddress = new Uri(BaseURI);

                    //Define request data format  
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await httpClient.PostAsJsonAsync("https://" + baseUrl +  "/api/Ordenes", orden);
                }

                var t = 1;

                return Json(new { success = true, message = "OK", data = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error" });
            }
        }



    }
}
