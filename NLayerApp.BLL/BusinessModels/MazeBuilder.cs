using NLayerApp.BLL_.DTO;
using NLayerApp.BLL_.DTO.Cells;
using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.BLL_.DTO.Items;

namespace NLayerApp.BLL_.BusinessModels
{
    public class MazeBuilder
    {
        private IMaze _maze;
        private Random _random = new Random();

        public IMaze Build(int width = 10,
            int height = 10,
            Action<IMaze> drawStepByStep = null)
        {
            _maze = new MazeDTO()
            {
                Width = width,
                Height = height,
                Cells = new List<BaseCell>(),
                DrawStepByStep = drawStepByStep
            };

            BuildWall();

            BuildGround();

            BuildGate();

            BuildGoldHeap();

            return _maze;
        }
        private void BuildWall()
        {
            for (int y = 0; y < _maze.Height; y++)
            {
                for (int x = 0; x < _maze.Width; x++)
                {
                    var wall = new Wall(x, y, _maze);
                    _maze.Cells.Add(wall);
                }
            }
        }
        private void BuildGround()
        {
            var randomCell = GetRandom(_maze.Cells);
            var wallsToDestroy = new List<BaseCell>()
            {
                //randomCell
            };
            var startCell = _maze.Cells.Single(x => x.CordinateX == 0 && x.CordinateY == 0);
            wallsToDestroy.Add(startCell);
            //_maze.Hero.X = randomCell.CordinateX;
            //_maze.Hero.Y = randomCell.CordinateY;

            _maze.Hero.X = 0;
            _maze.Hero.Y = 0;

            while (wallsToDestroy.Any())
            {
                ConsoleDrawer();

                var wallToDestroy = GetRandom(wallsToDestroy);

                var newGraundCell = ReplaceCellToGround(wallToDestroy);
                wallsToDestroy.Remove(wallToDestroy);

                var nearestWalls = GetNears<Wall>(newGraundCell);
                wallsToDestroy.AddRange(nearestWalls);

                wallsToDestroy = wallsToDestroy
                    .Where(wall => GetNears<Ground>(wall).Count() < 2)
                    .ToList();
            }
        }
        public void BuildGate()
        {
            var lastCell = _maze.Cells.Single(cell => cell.CordinateY == _maze.Height - 1
            && cell.CordinateX == _maze.Width - 1);
            var cell = FindNearestCell<Ground>(lastCell, "Ground");
            var gateCell = new Gate(cell.CordinateX, cell.CordinateY, _maze);
            ReplaceCell(gateCell);
            ConsoleDrawer();
        }

        public void BuildGoldHeap()
        {
            generateWithChance(10, "GoldHeap");
            ConsoleDrawer();
        }

        //метод принимает число до 100 которое представляет
        //собой долю клеток земли из их общего пула, и экземпляр клетки
        //копиями которой будут заменены клетки земли указанной доли.
        public IMaze generateWithChance(double chance, string cellType, BaseItem? item = null)
        {
            double chanceFactor = chance / 100;
            var AllGraundCells = _maze.Cells.OfType<Ground>().ToList();
            double numberOfGraundCells = AllGraundCells.Count;
            var numberOfCellsGenerated = numberOfGraundCells * chanceFactor;
            for (int i = 1; i < numberOfCellsGenerated; i++)
            {
                var oldCell = GetRandom(AllGraundCells);

                switch (cellType)
                {
                    case "Сhest":
                        if (item !=null)
                        {
                            var newСhest = new Сhest(oldCell.CordinateX, oldCell.CordinateY, _maze, item);
                            ReplaceCell(newСhest);
                        }
                        else { throw new NotImplementedException();}
                        break;
                    case "GoldHeap":
                        var newGoldHeap = new GoldHeap(oldCell.CordinateX, oldCell.CordinateY, _maze);
                        ReplaceCell(newGoldHeap);
                        break;
                    case "Lava":
                        var newLava = new Lava(oldCell.CordinateX, oldCell.CordinateY, _maze);
                        ReplaceCell(newLava);
                        break;
                    case "Water":
                        var newWater = new Water(oldCell.CordinateX, oldCell.CordinateY, _maze);
                        ReplaceCell(newWater);
                        break;
                }

                AllGraundCells.Remove(oldCell);
            }

            return _maze;
        }

        //метод находть ближайшую клетку определенного типа к определенной координате,
        //которую представляет клетка переданная в метод.
        private BaseCell FindNearestCell<T>(BaseCell сell, string cellType)
            where T : BaseCell
        {
            var startCell = сell;
            var differentTypeCells = new List<BaseCell>();
            while (startCell.GetType().Name != cellType)
            {
                var goodCells = GetNears<T>(startCell);
                if (goodCells.Any())
                {
                    return GetRandom(goodCells.ToList());
                }
                else
                {
                    differentTypeCells.AddRange(GetNears(startCell));
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
        private IEnumerable<BaseCell> GetNears(BaseCell cell)
        {
            return GetNears<BaseCell>(cell);
        }
        private IEnumerable<BaseCell> GetNears<CellType>(BaseCell cell)
            where CellType : BaseCell
        {
            return _maze.Cells
                .Where(c =>
                   Math.Abs(c.CordinateX - cell.CordinateX) == 0 && Math.Abs(c.CordinateY - cell.CordinateY) == 1
                || Math.Abs(c.CordinateX - cell.CordinateX) == 1 && Math.Abs(c.CordinateY - cell.CordinateY) == 0
                )
                .OfType<CellType>();
        }

        // метод GetNears находит все клетки лабиринта определенного типа находящиеся 
        // рядом с клеткой переданной в метод , Включяя тех что прилегают к ней по диагонали.
        private IEnumerable<BaseCell> GetNearsWhithDiagonals<CellType>(BaseCell cell)
           where CellType : BaseCell
        {
            var NearestCell = GetNears<CellType>(cell);
            var DiagonalCell = _maze.Cells
                .Where(c =>
                    Math.Abs(c.CordinateX - cell.CordinateX) == 1 && Math.Abs(c.CordinateY - cell.CordinateY) == 1
                ).OfType<CellType>();
            var result = new List<BaseCell>();
            result.AddRange(NearestCell);
            result.AddRange(DiagonalCell);
            return result;
        }
        private T GetRandom<T>(List<T> data)
        {
            var index = _random.Next(data.Count);
            return data[index];
        }
        public void ReplaceCell(BaseCell newCell)
        {
            var oldCell = _maze.Cells.Single(cell => cell.CordinateX == newCell.CordinateX && cell.CordinateY == newCell.CordinateY);
            _maze.Cells.Remove(oldCell);
            _maze.Cells.Add(newCell);
        }

        public BaseCell ReplaceCellToGround(BaseCell oldCell)
        {
            var ground = new Ground(oldCell.CordinateX, oldCell.CordinateY, oldCell.Maze);
            ReplaceCell(ground);
            return ground;
        }

        public void ConsoleDrawer()
        {
            if (_maze.DrawStepByStep != null)
            {
                _maze.DrawStepByStep.Invoke(_maze);
                //Thread.Sleep(100);
            }
        }

        public IMaze StateOfTheMaze()
        {
            var oldCell = _maze.Cells.Single(x => x.CordinateX == _maze.Hero.X 
            && x.CordinateY == _maze.Hero.Y);
            string cellType = oldCell.GetType().Name;
            switch (cellType)
            {
                case "Сhest":
                    //сначала нужно добавить новый тип клетое будут называться OpenChest
                    //и заменять эту клетку на клетку нового типа.
                    break;
                case "GoldHeap":
                    ReplaceCellToGround(oldCell);
                    break;
                case "Lava":
                    // требуется написать всю логику связанную с отображением смерти персонажа.
                    break;
                case "Water":
                    // требуется придумать как будет отображаться урон.
                    break;
            }
            return _maze;
        }
    }
}