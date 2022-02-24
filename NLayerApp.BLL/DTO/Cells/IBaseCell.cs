using NLayerApp.BLL_.DTO.Interfaces;

namespace NLayerApp.BLL_.DTO.Cells
{
    public interface IBaseCell
    {
        int CordinateX { get; set; }
        int CordinateY { get; set; } 
        IMaze Maze { get; set; }
        bool TryStep();
    }
}