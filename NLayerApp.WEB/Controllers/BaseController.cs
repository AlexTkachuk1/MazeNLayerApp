using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerApp.BLL_.Interfaces;

namespace NLayerApp.WEB.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        public IMazeService mazeService;

        public readonly IMapper mapper;
        public BaseController(
            IMapper mapper,
            IMazeService mazeSetvice)
        {
            this.mazeService = mazeSetvice;
            this.mapper = mapper;
        }
    }
}
