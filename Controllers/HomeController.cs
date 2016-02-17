using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using turplanlegger.Services;
using turplanlegger.ViewModels;

namespace turplanlegger.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITurbasenService _turbasenService;
        
        public HomeController(ITurbasenService turbasenService)
        {
            _turbasenService = turbasenService;
        }
        
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            var turListe = await _turbasenService.GetTurer();
            ViewData["TestData"] = turListe.Turer.Count.ToString();
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
    }
}
