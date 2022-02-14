using NLayerApp.BLL_.BusinessModels;
using NLayerApp.BLL_.DTO.Interfaces;

namespace NLayerApp.BLL_.DTO.Cells
{
    public class GoldHeap : BaseCell
    {
        private int goldCount;
        private Random _random = new Random();
        public GoldHeap(int x, int y, IMaze maze) : base(x, y, maze)
        {
            //if (goldCount < 0)
            //{
            //    throw new Exception("Gold heap can't has negative gold count");
            //}

            this.goldCount = _random.Next(1,60);
        }

        public override bool TryStep()
        {
            Maze.Hero.Gold += goldCount;
            return true;
        }
    }
}
