using NLayerApp.BLL_.DTO.Cells;
using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.BLL_.Interfaces;

namespace NLayerApp.BLL_.Services
{
    public class MazeBuildService : IMazeBuildService
    {
        private Random _random;

        public MazeBuildService()
        {
            _random = new Random();
        }
        public IMaze generateCells<T>(List<IBaseCell> cellsForReplace, IMaze maze) where T : IBaseCell, new()
        {
            for (int i = 0; i < cellsForReplace.Count; i++)
            {
                var newCell = new T();
                newCell.CordinateX = cellsForReplace[i].CordinateX;
                newCell.CordinateY = cellsForReplace[i].CordinateY;
                newCell.Maze = maze;
                ReplaceCell(newCell, maze);
            }
            return maze;
        }

        public List<IBaseCell> generateTheNumberOfCells<T>(int number, IMaze maze)
            where T : IBaseCell
        {
            var graundCells = maze.Cells.OfType<T>().ToList();
            var cells = new List<IBaseCell>();
            for (int i = 0; i < number; i++)
            {
                var cell = GetRandom<T>(graundCells);
                cells.Add(cell);
            }
            return cells;
        }

        ////метод принимает число до 100 которое представляет
        ////собой долю клеток земли из их общего пула, и экземпляр клетки
        ////копиями которой будут заменены клетки земли указанной доли.
        public List<IBaseCell> generateWithChance<T>(double chance, IMaze maze)
                where T : IBaseCell
        {
            double chanceFactor = chance / 100;
            var graundCells = maze.Cells.OfType<T>().ToList();

            double numberOfGraundCells = graundCells.Count;
            var numberOfCellsGenerated = (int)Math.Round(numberOfGraundCells * chanceFactor);

            var cells = new List<IBaseCell>();

            for (int i = 0; i < numberOfCellsGenerated; i++)
            {
                var cell = GetRandom<T>(graundCells);
                cells.Add(cell);
            }
            return cells;
        }
        public List<IBaseCell> generateWithTrueChance<T>(int chance, IMaze maze)
            where T : IBaseCell
        {
            var graundCells = maze.Cells.OfType<T>().ToList();
            var cells = new List<IBaseCell>();
            for (int i = 0; i < graundCells.Count; i++)
            {
                int number = _random.Next(0, 1000);
                if (chance > number)
                {
                    var cell = GetRandom<T>(graundCells);
                    cells.Add(cell);
                }
            }
            return cells;
        }

        //метод находть ближайшую клетку определенного типа к определенной координате,
        //которую представляет клетка переданная в метод.
        public IBaseCell FindNearestCell<T>(IBaseCell сell, string cellType, IMaze maze)
        where T : IBaseCell
        {
            var startCell = сell;
            var differentTypeCells = new List<IBaseCell>();
            while (startCell.GetType().Name != cellType)
            {
                var goodCells = GetNears<T>(startCell, maze);
                if (goodCells.Any())
                {
                    return GetRandom(goodCells.ToList());
                }
                else
                {
                    differentTypeCells.AddRange(GetNears(startCell, maze));
                }

                if (differentTypeCells.Any())
                {
                    startCell = GetRandom(differentTypeCells);
                    differentTypeCells.Remove(startCell);
                }
            }
            return startCell;
        }

        // метод GetNears находит все клетки лабиринта определенного типа находящиеся 
        // рядом с клеткой переданной в метод , кроме тех что прилегают к ней по диагонали.
        public IEnumerable<IBaseCell> GetNears(IBaseCell cell, IMaze maze)
        {
            return GetNears<IBaseCell>(cell, maze);
        }
        public IEnumerable<CellType> GetNears<CellType>(IBaseCell cell, IMaze maze)
            where CellType : IBaseCell
        {
            return maze.Cells
                .Where(c =>
                   Math.Abs(c.CordinateX - cell.CordinateX) == 0 && Math.Abs(c.CordinateY - cell.CordinateY) == 1
                || Math.Abs(c.CordinateX - cell.CordinateX) == 1 && Math.Abs(c.CordinateY - cell.CordinateY) == 0
                )
                .OfType<CellType>();
        }

        // метод GetNears находит все клетки лабиринта определенного типа находящиеся 
        // рядом с клеткой переданной в метод , Включяя тех что прилегают к ней по диагонали.
        public IEnumerable<CellType> GetNearsWhithDiagonals<CellType>(IBaseCell cell, IMaze maze)
           where CellType : IBaseCell
        {
            var NearestCell = GetNears<CellType>(cell, maze);
            var DiagonalCell = maze.Cells
                .Where(c =>
                    Math.Abs(c.CordinateX - cell.CordinateX) == 1 && Math.Abs(c.CordinateY - cell.CordinateY) == 1
                ).OfType<CellType>();
            var result = new List<CellType>();
            result.AddRange(NearestCell);
            result.AddRange(DiagonalCell);
            return result;
        }
        public T GetRandom<T>(List<T> data)
        {
            var index = _random.Next(data.Count);
            return data[index];
        }
        public IMaze ReplaceCell(IBaseCell newCell, IMaze maze)
        {
            var oldCell = maze.Cells.Single(cell => cell.CordinateX == newCell.CordinateX && cell.CordinateY == newCell.CordinateY);
            maze.Cells.Remove(oldCell);
            maze.Cells.Add(newCell);
            return maze;
        }

        public IBaseCell ReplaceCellToGround(IBaseCell oldCell, IMaze maze)
        {
            var ground = new Ground(oldCell.CordinateX, oldCell.CordinateY, oldCell.Maze);
            ReplaceCell(ground, maze);
            return ground;
        }
        public IMaze StateOfTheMaze(IMaze maze)
        {
            var oldCell = maze.Cells.Single(x => x.CordinateX == maze.Hero.X
            && x.CordinateY == maze.Hero.Y);
            string cellType = oldCell.GetType().Name;
            switch (cellType)
            {
                case "Сhest":
                    //сначала нужно добавить новый тип клетое будут называться OpenChest
                    //и заменять эту клетку на клетку нового типа.
                    break;
                case "GoldHeap":
                    ReplaceCellToGround(oldCell, maze);
                    break;
                case "Lava":
                    // требуется написать всю логику связанную с отображением смерти персонажа.
                    break;
                case "Trap":
                    // требуется придумать как будет отображаться урон.
                    break;
            }
            return maze;
        }
    }
}
