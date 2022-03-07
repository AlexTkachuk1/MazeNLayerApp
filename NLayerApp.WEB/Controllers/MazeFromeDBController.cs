using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerApp.BLL_.Interfaces;
using NLayerApp.WEB.Models;

namespace NLayerApp.WEB.Controllers
{
    public class MazeFromeDBController : Controller
    {
        IHeroService heroService;
        IMazeService mazeService;
        public readonly IMapper mapper;
        public MazeFromeDBController(
            IHeroService heroService,
            IMapper mapper,
            IMazeService mazeService)
        {
            this.heroService = heroService;
            this.mapper = mapper;
            this.mazeService = mazeService;
        }

        [HttpGet]
        public IActionResult CreateMaze()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DrawFromDb()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetBaseLabyrinth()
        {
            var allMazes = mazeService.GetAllMazes();
            var maze = allMazes[0];
            var mazeVievModel = mapper.Map<ReadyMazeViewModel>(maze);
            mazeVievModel.Hero = mapper.Map<HeroViewModel>(maze.Hero);
            for (int i = 0; i < maze.Hero.Inventory.Count; i++)
            {
                var item = mapper.Map<ItemViewModel>(maze.Hero.Inventory[i]);
                mazeVievModel.Hero.Inventory.Add(item);
            }
            for (int i = 0; i < maze.Cells.Count; i++)
            {
                var cell = mapper.Map<CellViewModel>(maze.Cells[i]);
                mazeVievModel.CellViewModels.Add(cell);
            }
            return new JsonResult(mazeVievModel);
        }
        protected override void Dispose(bool disposing)
        {
            mazeService.Dispose();
            base.Dispose(disposing);
        }
    }
}
