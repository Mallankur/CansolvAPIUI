using CansolvUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CansolvUI.Controllers
{
    public class CansolvUIController : Controller
    {

        Uri baseAddress = new Uri("https://10.2.10.19:44395/api");
        private readonly HttpClient _Client;
        public CansolvUIController()
        {
                _Client = new HttpClient();
            _Client.BaseAddress = baseAddress;  
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<UICansolve> cansolvDataList = new List<UICansolve>();
            HttpResponseMessage response = _Client.GetAsync(_Client.BaseAddress +
                "/CanSolve/Get/GetAsync").Result;
            if (response.IsSuccessStatusCode)
            { 
                string data = response.Content.ReadAsStringAsync().Result;
                cansolvDataList = JsonConvert.DeserializeObject<List<UICansolve>>(data);

            }
            
            return View(cansolvDataList);
        }
    }
}
