using NLayerApp.BLL_.DTO;
using NLayerApp.BLL_.DTO.Cells;
using NLayerApp.BLL_.DTO.Interfaces;

namespace NLayerApp.BLL_.BusinessModels
{
    public class MazeBuilderTest
    {
        private IMaze _maze;
        private readonly Random _random = new Random();
        private Action<IMaze> _drawStepByStep;
        public IMaze Build(int width = 30,
            int height = 15,
            Action<IMaze> drawStepByStep = null)
        {
            _drawStepByStep = drawStepByStep;
            _maze = new MazeDTO()
            {
                Width = width,
                Height = height,
                Cells = new List<IBaseCell>()
            };

            _maze = BuildWall(_maze);

            _maze = BuildGround(_maze);

            _maze = BuildGates(_maze);

            if (_drawStepByStep != null)
            {
                _drawStepByStep.Invoke(_maze);
                Thread.Sleep(100);
            }

            return _maze;
        }

        private IMaze BuildWall(IMaze maze)
        {
            for(int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Width; x++)
                {
                    var wall = new Wall(x, y, maze);
                    maze.Cells.Add(wall);
                }
            }
            return maze;
        }

        public IMaze BuildGround(IMaze maze)
        {
            var wallsToDestroy = new List<IBaseCell>() {
                maze.Cells[0]
            };

            _maze.Hero.X = 0;
            _maze.Hero.Y = 0;

            var cellVisited = new List<IBaseCell>();
            var allWallsToDestroy = wallsToDestroy;
            while (wallsToDestroy.Any() && allWallsToDestroy.Any())
            {

                if (wallsToDestroy.Any())
                {
                    var ToDestroy = GetRandom(wallsToDestroy);
                    allWallsToDestroy.Remove(ToDestroy);

                    var ground = ReplaceCellToGround(ToDestroy, maze);
                    wallsToDestroy.Remove(ToDestroy);

                    cellVisited.Add(ground);
                    wallsToDestroy = new List<IBaseCell>();

                    var nearestWalls = GetNears<Wall>(ground, maze);


                    wallsToDestroy.AddRange(nearestWalls);


                    wallsToDestroy = wallsToDestroy
                        .Where(wall => GetNears<Ground>(wall, maze).Count() < 2)
                        .ToList();
                    wallsToDestroy = wallsToDestroy.Where(wall => GetNearsWhithDiagonals<Ground>(wall, maze).Count() < 3)
                        .ToList();
                    allWallsToDestroy.AddRange(wallsToDestroy);
                    while (!wallsToDestroy.Any() && allWallsToDestroy.Any())
                    {
                        allWallsToDestroy = allWallsToDestroy.Where(wall => GetNearsWhithDiagonals<Ground>(wall, maze).Count() < 3)
                        .ToList();
                        var randomCellVisited = GetRandom(cellVisited);
                        var allNearestWalls = GetNearsWhithDiagonals<Wall>(randomCellVisited, maze);
                        var newWallToDestroy = allNearestWalls.Where(wall => GetNears<Ground>(wall, maze).Count() < 2)
                        .ToList();
                        if (newWallToDestroy.Any())
                        {
                            wallsToDestroy.Add(GetRandom(newWallToDestroy));
                        }
                        else
                        {
                            cellVisited.Remove(randomCellVisited);
                        }
                    }
                }
            }
            return maze;
        }

        public IMaze BuildGates(IMaze maze)
        {
            var lastCell = maze.Cells.Single(cell => cell.CordinateY == maze.Height - 1
            && cell.CordinateX == maze.Width - 1);
            var cell = FindNearestCell<Ground>(lastCell, "Ground", maze);
            var gateCell = new Gate(cell.CordinateX, cell.CordinateY, maze);
            ReplaceCell(gateCell, maze);
            return maze;
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
    }
}
