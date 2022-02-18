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
            return db.Heroes.First();
        }

        public void Create(Hero hero)
        {
            db.Heroes.Add(hero);
        }

        public void Update(Hero hero)
        {
            var heroForUpdate = db.Heroes.SingleOrDefault(x => x.Id == hero.Id);
            heroForUpdate.X = hero.X;
            heroForUpdate.Y = hero.Y;
            heroForUpdate.Damage = hero.Damage;
            heroForUpdate.Gold = hero.Gold;
            heroForUpdate.Stamina = hero.Stamina;
            heroForUpdate.Armor = hero.Armor;
            db.SaveChanges();
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
