using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.BLL_.Interfaces;
using NLayerApp.DAL_.Entities;
using NLayerApp.WEB.Models;

namespace NLayerApp.WEB.Controllers
{
    public class MazeController : Controller
    {
        IHeroService heroService;
        IMazeService mazeService;
        public readonly IMapper mapper;
        public MazeController(
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
        public IActionResult StartGame()
        {
            heroService.ReturnDefaultHeroStatus();
            return RedirectToAction("DrawJs", "Maze");
        }
        public IActionResult DrawJs()
        {
            return View();
        }

        public IActionResult DrawFromDb()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddNewItems([FromQuery(Name = "Name")] string cellTypeName)
        {
            heroService.StepOnMiracleShop(cellTypeName);
            return RedirectToAction("MiracleShop", "Maze");
        }

        [HttpPost]
        public IActionResult HeroStepOnGold([FromQuery(Name = "Name")] string cellTypeName)
        {

            switch (cellTypeName)
            {
                case "Сhest":
                    heroService.StepOnСhest();
                    break;
                case "Water":
                    heroService.StepOnWater();
                    break;
                case "Trap":
                    heroService.StepOnTrap();
                    break;
                case "GoldHeap":
                    heroService.StepOnGoldHeap();
                    break;
                case "Gate":
                    heroService.StepOnGate();
                    break;
                case "BrokenTrap":
                    heroService.BrokenTrap();
                    break;
                case "Legionary":
                    heroService.StepOnLegionary();
                    break;
                case "Rip":
                    heroService.StepOnRip();
                    break;
                case "Boss":
                    heroService.StepOnBoss();
                    break;
                case "Wall":
                    heroService.StepOnWall();
                    break;
                case "Teleport":
                    heroService.StepOnTeleport();
                    break;
                case "Killer":
                    heroService.StepOnKiller();
                    break;
            }

            return StatusCode(200);

        }

        public IActionResult GameOver()
        {
            heroService.ReturnDefaultHeroStatus();
            return View();
        }
        public IActionResult Menu()
        {
            return View();
        }
        [HttpGet]
        public IActionResult HeroIndicators()
        {
            var hero = heroService.GetHero();
            var heroViewModel = mapper.Map<HeroViewModel>(hero);
            return new JsonResult(heroViewModel);
        }
        public IActionResult GetHeroStatus()
        {
            var hero = heroService.GetHero();
            var heroViewModel = mapper.Map<HeroViewModel>(hero);
            return new JsonResult(heroViewModel);
        }
        public IActionResult BuildMaze(MazeViewModel mazeViewModel)
        {
            var mazeHeight = mazeViewModel.Height;
            var mazeWidth = mazeViewModel.Width;
            IMaze maze = mazeService.BuildMaze(mazeWidth, mazeHeight);
            maze.Name = mazeViewModel.Name;
            mazeService.SaveMaze(maze);
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

        [HttpGet]
        public IActionResult MazeDataForJs()
        {
            IMaze maze = mazeService.BuildMaze();

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


            var mazeDrawJsModel = mapper.Map<ReadyMazeViewModel>(maze);
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