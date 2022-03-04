using NLayerApp.BLL_.DTO.Cells;
using NLayerApp.BLL_.DTO.Interfaces;

namespace NLayerApp.BLL_.DTO
{
    public class MazeDTO: IMaze
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<IBaseCell> Cells { get; set; }
        public List<IBaseCell> CellsWithHero
        {
            get
            {
                var copyCells = Cells.ToList();
                var badCell = copyCells.Single(c => c.CordinateX == Hero.X && c.CordinateY == Hero.Y);
                copyCells.Remove(badCell);
                var cellWithHero = new CellWithHero(Hero, this);
                cellWithHero.CordinateX = Hero.X;
                cellWithHero.CordinateY = Hero.Y;
                copyCells.Add(cellWithHero);
                return copyCells;
            }
        }
        public IHero Hero
        {
            get
            {
                return HeroSingleton.GetHero();
            }
        }

        public IBaseCell this[int x, int y]
        {
            get
            {
                return Cells.SingleOrDefault(c => c.CordinateX == x && c.CordinateY == y);
            }
            set
            {
                var oldCell = Cells.SingleOrDefault(c => c.CordinateX == x && c.CordinateY == y);
                Cells.Remove(oldCell);
                Cells.Add(value);
            }
        }
        public void TryToStep(Direction direction)
        {
            var destinationX = Hero.X;
            var destinationY = Hero.Y;
            switch (direction)

            {
                case Direction.Up:
                    destinationY--;
                    break;
                case Direction.Right:
                    destinationX++;
                    break;
                case Direction.Down:
                    destinationY++;
                    break;
                case Direction.Left:
                    destinationX--;
                    break;
                default:
                    throw new Exception("Unkown direction");
            }

            var cellDestination = this[destinationX, destinationY];
            if (cellDestination?.TryStep() ?? false)
            {
                Hero.X = destinationX;
                Hero.Y = destinationY;
            }
        }
    }
}
