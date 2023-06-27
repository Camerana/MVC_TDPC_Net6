using Microsoft.AspNetCore.Mvc;
using MVC_TDPC_Net6.Models;
using System.Diagnostics;

namespace MVC_TDPC_Net6.Controllers
{
    /*
    - Creare nella pagina Javascript.cshtml un nuovo tasto che
    chiami un endpoint di tipo GET GetMusicModels che restituisca
    una lista di oggetti di tipo MusicModel (da creare nella
    folder models).
    - la classe Music ha due properties:
        - string Cantante
        - string Canzone
    - Loggare in console e scrivere in pagina il risultato ottenuto 
    dall'endpoint
     
     */
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
        public IActionResult ButtonPage()
        {
            return View();
        }
        public IActionResult Javascript()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}