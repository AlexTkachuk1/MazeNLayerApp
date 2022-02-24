using NLayerApp.BLL_.DTO.Interfaces;

namespace NLayerApp.BLL_.DTO.Cells
{
    public class InvisibleTrap : IBaseCell
    {
        public int CordinateX { get; set; }
        public int CordinateY { get; set; }
        public IMaze Maze { get; set; }
        public InvisibleTrap()
        {

        }
        public InvisibleTrap(int x, int y, IMaze maze)
        {
            CordinateX = x;
            CordinateY = y;
            Maze = maze;
        }

        public bool TryStep()
        {
            throw new NotImplementedException();
        }
    }
}
