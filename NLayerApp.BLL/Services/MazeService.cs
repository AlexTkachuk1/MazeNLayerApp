using AutoMapper;
using NLayerApp.BLL_.BusinessModels;
using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.BLL_.Interfaces;
using NLayerApp.DAL_.Entities;
using NLayerApp.DAL_.Interfaces;

namespace NLayerApp.BLL_.Services
{
    public class MazeService:IMazeService
    {
        IUnitOfWork Database { get; set; }
        public readonly IMapper mapper;
        public MazeService(
            IMapper mapper,
            IUnitOfWork uow)
        {
            Database = uow;
            this.mapper = mapper;
        }
        public  IMaze BuildMaze(int width = 20, int height = 10)
        {
            var builder = new MazeBuilder();
            IMaze newMaze = builder.Build(width, height);
            return newMaze;
        }
        public void SaveMaze(IMaze maze)
        {
            var mazeForSave = mapper.Map<Maze>(maze);
            Database.Mazes.Create(mazeForSave);

            var hero = mapper.Map<Hero>(maze.Hero);
            hero.Maze = mazeForSave;
            Database.Heroes.Create(hero);

            for (int i = 0; i < maze.Hero.Inventory.Count; i++)
            {
                var item = mapper.Map<Item>(maze.Hero.Inventory[i]);
                item.Hero = hero;
                Database.Items.Create(item);
            }

            for (int c = 0; c < maze.Cells.Count; c++)
            {
                var cell = mapper.Map<Cell>(maze.Cells[c]);
                cell.Maze = mazeForSave;
                Database.Cells.Create(cell);
            }
            Database.Save();
        }
        public List<Maze> GetAllMazes()
        {
            return Database.Mazes.GetAll().ToList();
        }
            public void Dispose()
        {
            Database.Dispose();
        }
    }
}
