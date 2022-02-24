using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.BLL_.DTO.Items;

namespace NLayerApp.BLL_.DTO.Cells
{
    public class Сhest : IBaseCell
    {
        public int CordinateX { get; set; }
        public int CordinateY { get; set; }
        public IMaze Maze { get; set; }
        public Сhest()
        {

        }
        public Сhest(int x, int y, IMaze maze)
        {
            CordinateX = x;
            CordinateY = y;
            Maze = maze;
        }

        public bool TryStep()
        {
            return true;
        }
    }
}
