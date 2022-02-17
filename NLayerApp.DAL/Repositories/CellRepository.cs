using NLayerApp.DAL_.EF;
using NLayerApp.DAL_.Entities;
using NLayerApp.DAL_.Interfaces;
using System.Data.Entity;

namespace NLayerApp.DAL_.Repositories
{
    public class CellRepository : IRepository<Cell>
    {
        private MazeDbContext db;

        public CellRepository(MazeDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Cell> GetAll()
        {
            return db.Cells;
        }

        public Cell Get(int id)
        {
            return db.Cells.Find(id);
        }

        public void Create(Cell cell)
        {
            db.Cells.Add(cell);
        }

        public void Update(Cell cell)
        {
            db.Entry(cell).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        }

        public IEnumerable<Cell> Find(Func<Cell, Boolean> predicate)
        {
            return db.Cells.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Cell cell = db.Cells.Find(id);
            if (cell != null)
                db.Cells.Remove(cell);
        }
    }
}