using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.DAL_.Entities;

namespace NLayerApp.BLL_.Interfaces
{
    public interface IMazeService
    {
        IMaze BuildMaze(int width = 16, int height = 10);

        IMaze BuildMazeCursedForest(int width = 16, int height = 10);

        IMaze BuildMazePoisonSwamps(int width = 16, int height = 10);
        void SaveMaze(IMaze maze);
        List<Maze> GetAllMazes();
        void Dispose();
    }
}
