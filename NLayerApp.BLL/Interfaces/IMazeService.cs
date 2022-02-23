using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.DAL_.Entities;

namespace NLayerApp.BLL_.Interfaces
{
    public interface IMazeService
    {
        IMaze BuildMaze(int width = 26, int height = 18);

        IMaze BuildMazeCursedForest(int width = 26, int height = 18);

        IMaze BuildMazePoisonSwamps(int width = 26, int height = 18);
        void SaveMaze(IMaze maze);
        List<Maze> GetAllMazes();
        void Dispose();
    }
}
