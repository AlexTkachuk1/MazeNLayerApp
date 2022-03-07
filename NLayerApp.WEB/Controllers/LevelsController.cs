using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.BLL_.Interfaces;
using NLayerApp.WEB.Models;

namespace NLayerApp.WEB.Controllers
{
    public class LevelsController : Controller
    {
        IMazeService mazeService;
        public readonly IMapper mapper;
        public LevelsController(
            IMapper mapper,
            IMazeService mazeService)
        {
            this.mapper = mapper;
            this.mazeService = mazeService;
        }

        public IActionResult DrawPoisonSwamps()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MazeDataForPoisonSwamps()
        {
            IMaze maze = mazeService.BuildMazePoisonSwamps();
            return new JsonResult(BuildReadyMazeViewModel(maze));
        }

        public IActionResult DrawCursedForest()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MazeDataForCursedForest()
        {
            IMaze maze = mazeService.BuildMazeCursedForest();
            return new JsonResult(BuildReadyMazeViewModel(maze));
        }

        [HttpGet]
        public IActionResult DrawFirstMaze()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DataForFirstMaze()
        {
            IMaze maze = mazeService.BuildMaze();
            return new JsonResult(BuildReadyMazeViewModel(maze));
        }

        [HttpGet]
        public IActionResult DrowForestOfSouls()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MazeDataForestOfSouls()
        {
            IMaze maze = mazeService.BuildMazeForestOfSouls();
             return new JsonResult(BuildReadyMazeViewModel(maze));
        }

        public ReadyMazeViewModel BuildReadyMazeViewModel(IMaze maze)
        {
            var cells = new List<CellViewModel>();

            for (int c = 0; c < maze.Cells.Count; c++)
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


            var readyMazeViewModel = mapper.Map<ReadyMazeViewModel>(maze);
            readyMazeViewModel.Hero = hero;
            readyMazeViewModel.CellViewModels.AddRange(cells);
            return readyMazeViewModel;
        }

        protected override void Dispose(bool disposing)
        {
            mazeService.Dispose();
            base.Dispose(disposing);
        }
    }
}
