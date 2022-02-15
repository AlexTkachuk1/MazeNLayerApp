using NLayerApp.DAL_.EF;
using NLayerApp.DAL_.Entities;
using NLayerApp.DAL_.Interfaces;
using System.Data.Entity;

namespace NLayerApp.DAL_.Repositories
{
    public class MazeRepository: IRepository<Maze>
    {
        private MazeDbContext db;

        public MazeRepository(MazeDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Maze> GetAll()
        {
            return db.Mazes.Include(m => m.Creater);
        }

        public Maze Get(int id)
        {
            return db.Mazes.Find(id);
        }

        public void Create(Maze book)
        {
            db.Mazes.Add(book);
        }

        public void Update(Maze book)
        {
            db.Entry(book).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        }

        public IEnumerable<Maze> Find(Func<Maze, Boolean> predicate)
        {
            return db.Mazes.Include(o => o.Creater).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Maze maze = db.Mazes.Find(id);
            if (maze != null)
                db.Mazes.Remove(maze);
        }
    }
}
