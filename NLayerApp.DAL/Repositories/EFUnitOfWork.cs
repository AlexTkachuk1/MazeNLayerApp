using NLayerApp.DAL_.EF;
using NLayerApp.DAL_.Entities;
using NLayerApp.DAL_.Interfaces;

namespace NLayerApp.DAL_.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private MazeContext db;
        private MazeRepository mazeRepository;
        private UserRepository userRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new MazeContext(connectionString);
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