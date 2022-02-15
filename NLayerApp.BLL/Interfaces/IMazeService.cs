using NLayerApp.BLL_.DTO.Interfaces;

namespace NLayerApp.BLL_.Interfaces
{
    public interface IMazeService
    {
        IMaze BuildMaze(int width = 10, int height = 10);
        void Dispose();
    }
}
