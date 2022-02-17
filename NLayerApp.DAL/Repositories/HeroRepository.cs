using NLayerApp.DAL_.EF;
using NLayerApp.DAL_.Entities;
using NLayerApp.DAL_.Interfaces;
using System.Data.Entity;

namespace NLayerApp.DAL_.Repositories
{
    public class HeroRepository: IRepository<Hero>
    {
        private MazeDbContext db;

        public HeroRepository(MazeDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Hero> GetAll()
        {
            return db.Heroes;
        }

        public Hero Get(int id)
        {
            return db.Heroes.Find(id);
        }

        public void Create(Hero maze)
        {
            db.Heroes.Add(maze);
        }

        public void Update(Hero maze)
        {
            db.Entry(maze).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        }

        public IEnumerable<Hero> Find(Func<Hero, Boolean> predicate)
        {
            return db.Heroes.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Hero hero = db.Heroes.Find(id);
            if (hero != null)
                db.Heroes.Remove(hero);
        }
    }
}
