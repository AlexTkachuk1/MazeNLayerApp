using NLayerApp.BLL_.DTO.Interfaces;

namespace NLayerApp.BLL_.Interfaces
{
    public interface IMazeService
    {
        IMaze BuildMaze();
        void Dispose();
    }
}
