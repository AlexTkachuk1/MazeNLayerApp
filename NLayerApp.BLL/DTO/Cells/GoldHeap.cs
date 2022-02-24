using NLayerApp.BLL_.BusinessModels;
using NLayerApp.BLL_.DTO.Interfaces;

namespace NLayerApp.BLL_.DTO.Cells
{
    public class GoldHeap : IBaseCell
    {
        public int CordinateX { get; set; }
        public int CordinateY { get; set; }
        public IMaze Maze { get; set; }
        public GoldHeap()
        {

        }
        public GoldHeap(int x, int y, IMaze maze)
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
