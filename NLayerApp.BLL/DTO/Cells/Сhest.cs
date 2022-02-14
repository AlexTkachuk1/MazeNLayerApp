using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.BLL_.DTO.Items;

namespace NLayerApp.BLL_.DTO.Cells
{
    public class Сhest : BaseCell
    {

        private readonly List<BaseCell> Cells;
        public BaseItem item { get; set; }

        public Сhest(int x, int y, IMaze maze, BaseItem item) : base(x, y, maze)
        {
            this.item = item;
            Cells = maze.Cells;
        }

        public override bool TryStep()
        {
            Maze.Hero.Inventory.Add(item);

            //cellService.ReplaceCellToGround(this, Cells);

            return true;
        }
    }
}
