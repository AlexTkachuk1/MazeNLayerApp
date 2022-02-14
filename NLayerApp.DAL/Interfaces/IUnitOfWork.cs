using NLayerApp.DAL_.Entities;

namespace NLayerApp.DAL_.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Maze> Mazes { get; }
        void Save();
    }
}
