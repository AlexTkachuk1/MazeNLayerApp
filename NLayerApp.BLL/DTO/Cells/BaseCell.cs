using NLayerApp.BLL_.DTO.Interfaces;

namespace NLayerApp.BLL_.DTO.Cells
{
    public abstract class BaseCell
    {
        public int CordinateX { get; set; }
        public int CordinateY { get; set; }

        public IMaze Maze { get; set; }

        public BaseCell(int x, int y, IMaze maze)
        {
            CordinateX = x;
            CordinateY = y;
            Maze = maze;
        }

        public abstract bool TryStep();
    }
}