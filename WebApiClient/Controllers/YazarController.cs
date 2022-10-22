using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using WebApiClient.Models;


namespace WebApiClient.Controllers
{
    [RoutePrefix("Home/Yazar")]
    [Route("{action=index}")]
    public class YazarController : Controller
    {
        // GET: Yazar
        public ActionResult Index()
        {
            List<Yazar> yazar = new List<Yazar>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49986/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage mesaj = new HttpResponseMessage();
                try
                {
                    mesaj = client.GetAsync("api/yazar").Result;

                    if (mesaj.IsSuccessStatusCode)
                    {
                        yazar = mesaj.Content.ReadAsAsync<List<Yazar>>().Result;
                        ViewBag.message =  "Api Bağlantısı Başarılı";

                    }

                }
                catch
                {
                    ViewBag.message = "Api Bağlantısı Başarısız";
                }


            }
            return View(yazar);
        }
        public ActionResult Edit()
        {
            return View();
        }
    }
}