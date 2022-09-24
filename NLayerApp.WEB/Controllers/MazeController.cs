using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.BLL_.Interfaces;
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
        public IActionResult StartGame()
        {
            heroService.ReturnDefaultHeroStatus();
            return RedirectToAction("DrawFirstMaze", "Levels");
        }

        [HttpGet]
        public IActionResult AddNewItems([FromQuery (Name = "Name")] string cellTypeName)
        {
            heroService.StepOnMiracleShop(cellTypeName);
            return RedirectToAction("DrawFirstMaze", "Levels");
        }

        [HttpPost]
        public IActionResult HeroStepOnCell([FromQuery(Name = "Name")] string cellTypeName)
        {

            heroService.StepOn(cellTypeName);

            return StatusCode(200);

        }

        [HttpGet]
        public IActionResult GameOver()
        {
            heroService.ReturnDefaultHeroStatus();
            return View();
        }

        //[HttpGet]
        //public IActionResult Menu()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult HeroIndicators()
        {
            var hero = heroService.GetHero();
            var heroViewModel = mapper.Map<HeroViewModel>(hero);
            return new JsonResult(heroViewModel);
        }

        [HttpGet]
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

        protected override void Dispose(bool disposing)
        {
            mazeService.Dispose();
            base.Dispose(disposing);
        }
    }
}