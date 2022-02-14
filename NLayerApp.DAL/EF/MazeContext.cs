using NLayerApp.DAL_.Entities;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace NLayerApp.DAL_.EF
{
    public class MazeContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Maze> Mazes { get; set; }
        static MazeContext()
        {
            Database.SetInitializer<MazeContext>(new MazeDbInitializer());
        }

        public MazeContext(string connectionString) : base(connectionString)
        {
        }
    }
}
