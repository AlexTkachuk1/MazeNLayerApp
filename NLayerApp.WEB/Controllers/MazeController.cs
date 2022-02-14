using Microsoft.AspNetCore.Mvc;
using NLayerApp.BLL_.Interfaces;

namespace NLayerApp.WEB.Controllers
{
    public class MazeController : Controller
    {
        IMazeService mazeService;
        public MazeController(IMazeService serv)
        {
            mazeService = serv;
        }
        public IActionResult Index()
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            mazeService.Dispose();
            base.Dispose(disposing);
        }
    }
}
