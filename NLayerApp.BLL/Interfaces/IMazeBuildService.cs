using NLayerApp.BLL_.DTO.Cells;
using NLayerApp.BLL_.DTO.Interfaces;

namespace NLayerApp.BLL_.Interfaces
{
    public interface IMazeBuildService
    {
        List<IBaseCell> generateWithChance<T>(double chance, IMaze maze)
            where T : IBaseCell;
        IMaze generateCells<T>(List<IBaseCell> cellsForReplace, IMaze maze) 
            where T : IBaseCell, new();
        public List<IBaseCell> generateWithTrueChance<T>(int chance, IMaze maze)
            where T : IBaseCell;
        List<IBaseCell> generateTheNumberOfCells<T>(int number, IMaze maze)
            where T : IBaseCell;
        IBaseCell FindNearestCell<T>(IBaseCell сell, string cellType, IMaze maze) where T : IBaseCell;
        IEnumerable<IBaseCell> GetNears(IBaseCell cell, IMaze maze);
        IEnumerable<CellType> GetNears<CellType>(IBaseCell cell, IMaze maze)
           where CellType : IBaseCell;
        public IEnumerable<CellType> GetNearsWhithDiagonals<CellType>(IBaseCell cell, IMaze maze)
           where CellType : IBaseCell;
        T GetRandom<T>(List<T> data);
        IMaze ReplaceCell(IBaseCell newCell, IMaze maze);
        IBaseCell ReplaceCellToGround(IBaseCell oldCell, IMaze maze);
    }
}
