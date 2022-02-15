using Microsoft.AspNetCore.Mvc;
using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.BLL_.Interfaces;
using NLayerApp.WEB.Models;

namespace NLayerApp.WEB.Controllers
{
    public class MazeController : Controller
    {
        IMazeService mazeService;
        public MazeController(IMazeService serv)
        {
            mazeService = serv;
        }

        [HttpGet]
        public IActionResult CreateMaze()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Draw(MazeViewModel mazeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateMaze", mazeViewModel);
            }

            
            IMaze maze = mazeService.BuildMaze(mazeViewModel.Width, mazeViewModel.Height);

            var mazeDrawViewModel = new MazeDrawViewModel()
            {
                Width = maze.Width,
                Height = maze.Height,
                Cells = new string[maze.Width, maze.Height]
            };

            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Width; x++)
                {
                    mazeDrawViewModel.Cells[x, y] = maze[x, y].GetType().Name;
                }
            }

            return View(mazeDrawViewModel);
        }
        protected override void Dispose(bool disposing)
        {
            mazeService.Dispose();
            base.Dispose(disposing);
        }
    }
}
