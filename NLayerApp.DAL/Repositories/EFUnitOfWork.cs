using NLayerApp.DAL_.EF;
using NLayerApp.DAL_.Entities;
using NLayerApp.DAL_.Interfaces;

namespace NLayerApp.DAL_.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private MazeDbContext db;
        private MazeRepository mazeRepository;
        private UserRepository userRepository;
        private ItemRepository itemRepository;
        private CellRepository cellRepository;
        private HeroRepository heroRepository;
        public EFUnitOfWork(MazeDbContext mazeDbContext)
        {
            db = mazeDbContext;
        }
        public IRepository<Maze> Mazes
        {
            get
            {
                if (mazeRepository == null)
                    mazeRepository = new MazeRepository(db);
                return mazeRepository;
            }
        }
        public IRepository<Item> Items
        {
            get
            {
                if (itemRepository == null)
                    itemRepository = new ItemRepository(db);
                return itemRepository;
            }
        }
        public IRepository<Hero> Heroes
        {
            get
            {
                if (heroRepository == null)
                    heroRepository = new HeroRepository(db);
                return heroRepository;
            }
        }
        public IRepository<Cell> Cells
        {
            get
            {
                if (cellRepository == null)
                    cellRepository = new CellRepository(db);
                return cellRepository;
            }
        }
        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}