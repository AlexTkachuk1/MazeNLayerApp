using NLayerApp.BLL_.DTO.Interfaces;

namespace NLayerApp.BLL_.DTO.Cells
{
    public class Assassin : IBaseCell
    {
        public int CordinateX { get; set; }
        public int CordinateY { get; set; }
        public IMaze Maze { get; set; }
        public Assassin()
        {

        }
        public Assassin(int x, int y, IMaze maze)
        {
            CordinateX=x;
            CordinateY=y;
            Maze=maze;
        }

        public bool TryStep()
        {
            throw new NotImplementedException();
        }
    }
}
