using NLayerApp.BLL_.DTO;
using NLayerApp.BLL_.Interfaces;
using NLayerApp.DAL_.Interfaces;

namespace NLayerApp.BLL_.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateUser(UserDTO userDto)
        {

        }
        public MazeDTO GetMaze(int? id) 
        {
            return new MazeDTO();
        }
        public IEnumerable<MazeDTO> GetMazes()
        {
            return new List<MazeDTO>();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
