using NLayerApp.DAL_.Entities;

namespace NLayerApp.DAL_.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {

        IRepository<Item> Items { get; }
        IRepository<Hero> Heroes { get; }
        IRepository<Cell> Cells { get; }
        IRepository<Maze> Mazes { get; }
        IRepository<User> Users { get; }
        void Save();
    }
}
