﻿using NLayerApp.BLL_.DTO;
using NLayerApp.BLL_.DTO.Cells;
using NLayerApp.BLL_.DTO.Interfaces;

namespace NLayerApp.BLL_.BusinessModels
{
    public class MazeBuilder
    {
        private IMaze _maze;
        private Random _random = new Random();

        public IMaze Build(int width = 30,
            int height = 15,
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

            BuildTrap();

            BuildGoblin();

            BuildBoss();

            BuildСhest();

            BuildTeleport();

            BuildMiracleShop();

            BuildKiller();

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
        public void BuildGoblin()
        {
            generateWithChance(5, "Legionary");
            ConsoleDrawer();
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

        public void BuildTrap()
        {
            generateWithChance(5, "Trap");
            ConsoleDrawer();
        }
        public void BuildBoss()
        {
            generateWithChance(2, "Boss");
            ConsoleDrawer();
        }

        public void BuildСhest()
        {
            generateWithTrueChance(30, "Сhest");
            ConsoleDrawer();
        }

        public void BuildMiracleShop()
        {
            generateWithTrueChance(5, "MiracleShop");
            ConsoleDrawer();
        }
        public void BuildKiller()
        {
            generateWithTrueChance(5, "Killer");
            ConsoleDrawer();
        }
        public void BuildTeleport()
        {
            var graundCells = _maze.Cells.OfType<Ground>().ToList();
            var allGraundCells = new List<BaseCell>();
            allGraundCells.AddRange(graundCells);
            generateTheNumberOfCells(2, "Teleport", allGraundCells);
            ConsoleDrawer();
        }

        //метод принимает число до 100 которое представляет
        //собой долю клеток земли из их общего пула, и экземпляр клетки
        //копиями которой будут заменены клетки земли указанной доли.
        public IMaze generateWithChance(double chance, string cellType)
        {
            double chanceFactor = chance / 100;
            var graundCells = _maze.Cells.OfType<Ground>().ToList();

            double numberOfGraundCells = graundCells.Count;
            var numberOfCellsGenerated = (int)Math.Round(numberOfGraundCells * chanceFactor);

            var allGraundCells = new List<BaseCell>();
            allGraundCells.AddRange(graundCells);

            return generateTheNumberOfCells(numberOfCellsGenerated, cellType, allGraundCells);
        }
        public IMaze generateWithTrueChance(double chance, string cellType)
        {
            var graundCells = _maze.Cells.OfType<Ground>().ToList();
            var allGraundCells = new List<BaseCell>();
            allGraundCells.AddRange(graundCells);
            for (int i = 0; i < graundCells.Count; i++)
            {
                double number = _random.Next(0, 1000);
                if (chance > number)
                {
                    IMaze maze = generateTheNumberOfCells(1, cellType, allGraundCells);
                }
            }
            return _maze;
        }
        //метод получает название типа клетки и количество(int), а также принимает колекцию клеток ,
        //из которой будут случайно выбрано указанное количество клеток и заменено на указанный тип клеток. 
        public IMaze generateTheNumberOfCells(int numberOfCells, string cellType, List<BaseCell> cells)
        {
            for (int i = 0; i < numberOfCells; i++)
            {
                var oldCell = GetRandom(cells);

                switch (cellType)
                {
                    case "Сhest":
                        var newСhest = new Сhest(oldCell.CordinateX, oldCell.CordinateY, _maze);
                        ReplaceCell(newСhest);
                        break;
                    case "GoldHeap":
                        var newGoldHeap = new GoldHeap(oldCell.CordinateX, oldCell.CordinateY, _maze);
                        ReplaceCell(newGoldHeap);
                        break;
                    case "Water":
                        var newWater = new Water(oldCell.CordinateX, oldCell.CordinateY, _maze);
                        ReplaceCell(newWater);
                        break;
                    case "Wall":
                        var newWall = new Water(oldCell.CordinateX, oldCell.CordinateY, _maze);
                        ReplaceCell(newWall);
                        break;
                    case "Lava":
                        var newLava = new Lava(oldCell.CordinateX, oldCell.CordinateY, _maze);
                        ReplaceCell(newLava);
                        break;
                    case "Trap":
                        var newTrap = new Trap(oldCell.CordinateX, oldCell.CordinateY, _maze);
                        ReplaceCell(newTrap);
                        break;
                    case "Legionary":
                        var newLegionary = new Legionary(oldCell.CordinateX, oldCell.CordinateY, _maze);
                        ReplaceCell(newLegionary);
                        break;
                    case "Boss":
                        var newBoss = new Boss(oldCell.CordinateX, oldCell.CordinateY, _maze);
                        ReplaceCell(newBoss);
                        break;
                    case "Teleport":
                        var newTeleport = new Teleport(oldCell.CordinateX, oldCell.CordinateY, _maze);
                        ReplaceCell(newTeleport);
                        break;
                    case "MiracleShop":
                        var newMiracleShop = new MiracleShop(oldCell.CordinateX, oldCell.CordinateY, _maze);
                        ReplaceCell(newMiracleShop);
                        break;
                    case "Killer":
                        var newKiller = new Killer(oldCell.CordinateX, oldCell.CordinateY, _maze);
                        ReplaceCell(newKiller);
                        break;
                }

                cells.Remove(oldCell);
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
                case "Trap":
                    // требуется придумать как будет отображаться урон.
                    break;
            }
            return _maze;
        }
    }
}