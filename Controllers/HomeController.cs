using Microsoft.AspNetCore.Mvc;
using MVC_TDPC_Net6.Models;
using System.Diagnostics;

namespace MVC_TDPC_Net6.Controllers
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
            UserModel model = new UserModel();
            model.Name = "Ciccio";
            model.LastName = "Pasticcio";
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ButtonPage()
        {
            return View();
        }
        public IActionResult Music()
        {
            MusicModel model = new MusicModel();
            for (int i = 0; i < 10; i++)
            {
                model.Songs.Add(
                    new MusicModel.SongAndArtistModel()
                    {
                        ArtistName = "Artista " + i,
                        SongName = "Canzone " + i
                    });
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}