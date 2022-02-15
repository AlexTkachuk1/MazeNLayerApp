using NLayerApp.BLL_.BusinessModels;
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
        public  IMaze BuildMaze(int width = 10, int height = 10)
        {
            var builder = new MazeBuilder();
            IMaze newMaze = builder.Build(width, height);
            return newMaze;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
