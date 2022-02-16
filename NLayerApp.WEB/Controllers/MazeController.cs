using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.BLL_.Interfaces;
using NLayerApp.WEB.Models;

namespace NLayerApp.WEB.Controllers
{
    public class MazeController : Controller
    {
        IMazeService mazeService;
        public readonly IMapper mapper;
        public MazeController(
            IMapper mapper,
            IMazeService mazeService)
        {
            this.mapper = mapper;
            this.mazeService = mazeService;
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
        public IActionResult DrawJs()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MazeDataForJs()
        {
            IMaze maze = mazeService.BuildMaze();

            var cells = new List<CellViewModel>();

            for (int c = 0;c < maze.Cells.Count; c++)
            {
                var cell = mapper.Map<CellViewModel>(maze.Cells[c]);
                cells.Add(cell);
            }

            var items = new List<ItemViewModel>();

            for (int i = 0; i < maze.Hero.Inventory.Count; i++)
            {
                var item = mapper.Map<ItemViewModel>(maze.Hero.Inventory[i]);
                items.Add(item);
            }

            var hero = mapper.Map<HeroViewModel>(maze.Hero);
            hero.Inventory.AddRange(items);


            var mazeDrawJsModel = mapper.Map<MazeDataForJsViewModel>(maze);
            mazeDrawJsModel.Hero = hero;
            mazeDrawJsModel.CellViewModels.AddRange(cells);

            return new JsonResult(mazeDrawJsModel);
        }
        protected override void Dispose(bool disposing)
        {
            mazeService.Dispose();
            base.Dispose(disposing);
        }
    }
}