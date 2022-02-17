using Microsoft.EntityFrameworkCore;
using NLayerApp.DAL_.Entities;

namespace NLayerApp.DAL_.EF
{
    public class MazeDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Maze> Mazes { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Cell> Cells { get; set; }

        public MazeDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Maze>()
                .HasOne(x => x.Hero)
                .WithOne(x => x.Maze)
                .HasForeignKey<Hero>(p => p.MazeId);
            modelBuilder.Entity<Hero>()
                .HasMany(x => x.Inventory)
                .WithOne(x => x.Hero);
            modelBuilder.Entity<Maze>()
                .HasMany(x => x.Cells)
                .WithOne(x => x.Maze);

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
