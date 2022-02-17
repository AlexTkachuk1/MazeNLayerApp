using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.DAL_.Entities;

namespace NLayerApp.BLL_.Interfaces
{
    public interface IMazeService
    {
        IMaze BuildMaze(int width = 20, int height = 10);
        void SaveMaze(IMaze maze);
        List<Maze> GetAllMazes();
        Hero GetHero(int id);
        void UpdateHero(Hero hero);
        void Dispose();
    }
}
