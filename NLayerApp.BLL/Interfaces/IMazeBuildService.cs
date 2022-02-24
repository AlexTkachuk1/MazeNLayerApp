using NLayerApp.BLL_.DTO.Cells;
using NLayerApp.BLL_.DTO.Interfaces;

namespace NLayerApp.BLL_.Interfaces
{
    public interface IMazeBuildService
    {
        IMaze generateWithChance(double chance, string cellType, IMaze maze);
        T generateCells<T>() where T : new();
        IMaze generateWithTrueChance(double chance, string cellType, List<BaseCell> allCells, IMaze maze);
        IMaze generateTheNumberOfCells(int numberOfCells, string cellType, List<BaseCell> cells, IMaze maze);
        BaseCell FindNearestCell<T>(BaseCell сell, string cellType, IMaze maze) where T : BaseCell;
        IEnumerable<BaseCell> GetNears(BaseCell cell, IMaze maze);
        public IEnumerable<BaseCell> GetNears<CellType>(BaseCell cell, IMaze maze) where CellType : BaseCell;
        IEnumerable<BaseCell> GetNearsWhithDiagonals<CellType>(BaseCell cell, IMaze maze) where CellType : BaseCell;
        T GetRandom<T>(List<T> data);
        IMaze ReplaceCell(BaseCell newCell, IMaze maze);
        BaseCell ReplaceCellToGround(BaseCell oldCell, IMaze maze);
        IMaze StateOfTheMaze(IMaze maze);
    }
}
