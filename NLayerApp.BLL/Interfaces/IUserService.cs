using NLayerApp.BLL_.DTO;

namespace NLayerApp.BLL_.Interfaces
{
    public interface IUserService
    {
        void CreateUser(UserDTO userDto);
        MazeDTO GetMaze(int? id);
        IEnumerable<MazeDTO> GetMazes();
        void Dispose();
    }
}