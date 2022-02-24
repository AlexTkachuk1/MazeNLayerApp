using NLayerApp.BLL_.DTO.Interfaces;

namespace NLayerApp.BLL_.DTO.Cells
{
    public class CellWithHero : IBaseCell
    {
        public int CordinateX { get; set; }
        public int CordinateY { get; set; }
        public IMaze Maze { get; set; }
        public CellWithHero(IHero hero, IMaze maze)
        {

        }

        public bool TryStep()
        {
            throw new NotImplementedException();
        }
    }
}