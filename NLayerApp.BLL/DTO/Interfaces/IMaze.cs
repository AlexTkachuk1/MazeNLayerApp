using NLayerApp.BLL_.DTO.Cells;

namespace NLayerApp.BLL_.DTO.Interfaces
{
    public interface IMaze
    {
        List<IBaseCell> Cells { get; set; }
        List<IBaseCell> CellsWithHero { get; }
        IHero Hero { get; }
        int Height { get; set; }
        int Width { get; set; }
        string Name { get; set; }
        IBaseCell this[int x, int y] { get; set; }
        void TryToStep(Direction direction);
    }
}
