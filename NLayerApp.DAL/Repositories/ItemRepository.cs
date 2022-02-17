using NLayerApp.DAL_.EF;
using NLayerApp.DAL_.Entities;
using NLayerApp.DAL_.Interfaces;
using System.Data.Entity;

namespace NLayerApp.DAL_.Repositories
{
    public class ItemRepository : IRepository<Item>
    {
        private MazeDbContext db;

        public ItemRepository(MazeDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Item> GetAll()
        {
            return db.Items ;
        }

        public Item Get(int id)
        {
            return db.Items.Find(id);
        }

        public void Create(Item item)
        {
            db.Items.Add(item);
        }

        public void Update(Item item)
        {
            db.Entry(item).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        }

        public IEnumerable<Item> Find(Func<Item, Boolean> predicate)
        {
            return db.Items.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Item item = db.Items.Find(id);
            if (item != null)
                db.Items.Remove(item);
        }
    }
}
