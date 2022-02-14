using NLayerApp.BLL_.BusinessModels;
using NLayerApp.BLL_.DTO;
using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.BLL_.Interfaces;
using NLayerApp.DAL_.Interfaces;

namespace NLayerApp.BLL_.Services
{
    public class MazeService:IMazeService
    {
        IUnitOfWork Database { get; set; }

        public MazeService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public  IMaze BuildMaze()
        {
            var builder = new MazeBuilder();
            var newMaze = builder.Build();
            return newMaze;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
