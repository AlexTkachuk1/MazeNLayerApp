using NLayerApp.DAL_.EF;
using NLayerApp.DAL_.Entities;
using NLayerApp.DAL_.Interfaces;
using System.Data.Entity;

namespace NLayerApp.DAL_.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private MazeDbContext db;

        public UserRepository(MazeDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public void Create(User order)
        {
            db.Users.Add(order);
        }

        public void Update(User order)
        {
            db.Entry(order).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        }
        public IEnumerable<User> Find(Func<User, Boolean> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            User order = db.Users.Find(id);
            if (order != null)
                db.Users.Remove(order);
        }
    }
}