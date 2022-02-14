using NLayerApp.DAL_.Entities;
using System.Data.Entity;

namespace NLayerApp.DAL_.EF
{
    public class MazeDbInitializer : DropCreateDatabaseIfModelChanges<MazeContext>
    {
        protected override void Seed(MazeContext db)
        {
            db.Users.Add(new User { Login = "Admin",  });
            db.SaveChanges();
        }
    }
}
