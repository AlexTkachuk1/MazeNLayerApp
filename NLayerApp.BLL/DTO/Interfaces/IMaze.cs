using NLayerApp.BLL_.DTO.Cells;

namespace NLayerApp.BLL_.DTO.Interfaces
{
    public interface IMaze
    {
        List<BaseCell> Cells { get; set; }
        List<BaseCell> CellsWithHero { get; }
        IHero Hero { get; }
        int Height { get; set; }
        int Width { get; set; }
        Action<IMaze> DrawStepByStep { get; set; }
        void TryToStep(Direction direction);
    }
}
