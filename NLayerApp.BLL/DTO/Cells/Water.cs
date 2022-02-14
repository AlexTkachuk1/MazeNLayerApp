using NLayerApp.BLL_.DTO.Interfaces;

namespace NLayerApp.BLL_.DTO.Cells
{
    public class Water : BaseCell
    {
        private int damage;
        private Random _random = new Random();
        public Water(int x, int y, IMaze maze) : base(x, y, maze)
        {
            this.damage = _random.Next(5,15);
        }

        public override bool TryStep()
        {
            Maze.Hero.HP -= damage;
            return true;
        }
    }
}
