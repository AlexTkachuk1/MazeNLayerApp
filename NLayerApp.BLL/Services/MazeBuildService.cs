using NLayerApp.BLL_.DTO.Cells;
using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.BLL_.Interfaces;
using System.Reflection;

namespace NLayerApp.BLL_.Services
{
    public class MazeBuildService: IMazeBuildService
    {
        private Random _random;

        public MazeBuildService()
        {
            _random = new Random();
        }

        //метод принимает число до 100 которое представляет
        //собой долю клеток земли из их общего пула, и экземпляр клетки
        //копиями которой будут заменены клетки земли указанной доли.
        public IMaze generateWithChance(double chance, string cellType, IMaze maze)
        {
            double chanceFactor = chance / 100;
            var graundCells = maze.Cells.OfType<Ground>().ToList();

            double numberOfGraundCells = graundCells.Count;
            var numberOfCellsGenerated = (int)Math.Round(numberOfGraundCells * chanceFactor);

            var allGraundCells = new List<BaseCell>();
            allGraundCells.AddRange(graundCells);

            return generateTheNumberOfCells(numberOfCellsGenerated, cellType, allGraundCells, maze);
        }
        public IMaze generateWithTrueChance(double chance, string cellType, List<BaseCell> allCells, IMaze maze)
        {
            var newMaze = maze;
            var graundCells = allCells; /*_maze.Cells.OfType<Ground>().ToList()*/
            var allGraundCells = new List<BaseCell>();
            allGraundCells.AddRange(graundCells);
            for (int i = 0; i < graundCells.Count; i++)
            {
                double number = _random.Next(0, 1000);
                if (chance > number)
                {
                    newMaze = generateTheNumberOfCells(1, cellType, allGraundCells, maze);
                }
            }
            return newMaze;
        }
        public T generateCells<T>() where T : new()
        {
            T instance = new T();
            return instance;
        }

        //метод получает название типа клетки и количество(int), а также принимает колекцию клеток ,
        //из которой будут случайно выбрано указанное количество клеток и заменено на указанный тип клеток. 
        public IMaze generateTheNumberOfCells(int numberOfCells, string cellType, List<BaseCell> cells, IMaze maze)
        {
            for (int i = 0; i < numberOfCells; i++)
            {
                var oldCell = GetRandom(cells);



                switch (cellType)
                {
                    case "Сhest":
                        var newСhest = new Сhest(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newСhest, maze);
                        break;
                    case "GoldHeap":
                        var newGoldHeap = new GoldHeap(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newGoldHeap, maze);
                        break;
                    case "Water":
                        var newWater = new Water(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newWater, maze);
                        break;
                    case "Wall":
                        var newWall = new Water(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newWall, maze);
                        break;
                    case "Lava":
                        var newLava = new Lava(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newLava, maze);
                        break;
                    case "Trap":
                        var newTrap = new Trap(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newTrap, maze);
                        break;
                    case "Legionary":
                        var newLegionary = new Legionary(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newLegionary, maze);
                        break;
                    case "Boss":
                        var newBoss = new Boss(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newBoss, maze);
                        break;
                    case "Teleport":
                        var newTeleport = new Teleport(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newTeleport, maze);
                        break;
                    case "MiracleShop":
                        var newMiracleShop = new MiracleShop(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newMiracleShop, maze);
                        break;
                    case "Killer":
                        var newKiller = new Killer(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newKiller, maze);
                        break;
                    case "InvisibleTrap":
                        var newInvisibleTrap = new InvisibleTrap(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newInvisibleTrap, maze);
                        break;
                    case "Assassin":
                        var newAssassin = new Assassin(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newAssassin, maze);
                        break;
                    case "AverageTreatmentPotion":
                        var newAverageTreatmentPotion = new AverageTreatmentPotion(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newAverageTreatmentPotion, maze);
                        break;
                    case "BagOfGold":
                        var newBagOfGold = new BagOfGold(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newBagOfGold, maze);
                        break;
                    case "Champion":
                        var newChampion = new Champion(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newChampion, maze);
                        break;
                    case "DamnEarth":
                        var newDamnEarth = new DamnEarth(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newDamnEarth, maze);
                        break;
                    case "DeadMan":
                        var newDeadMan = new DeadMan(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newDeadMan, maze);
                        break;
                    case "Draconian":
                        var newDraconian = new Draconian(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newDraconian, maze);
                        break;
                    case "Dragon":
                        var newDragon = new Dragon(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newDragon, maze);
                        break;
                    case "Elf":
                        var newElf = new Elf(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newElf, maze);
                        break;
                    case "ExperiencedWarrior":
                        var newExperiencedWarrior = new ExperiencedWarrior(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newExperiencedWarrior, maze);
                        break;
                    case "Goblin":
                        var newGoblin = new Goblin(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newGoblin, maze);
                        break;
                    case "Mutant":
                        var newMutant = new Mutant(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newMutant, maze);
                        break;
                    case "Robot":
                        var newRobor = new Robot(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newRobor, maze);
                        break;
                    case "SmallPotionTreatment":
                        var newSmallPotionTreatment = new SmallPotionTreatment(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newSmallPotionTreatment, maze);
                        break;
                    case "SwampCreature":
                        var newSwampCreature = new SwampCreature(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newSwampCreature, maze);
                        break;
                    case "DecomposedCorpse":
                        var newDecomposedCorpse = new DecomposedCorpse(oldCell.CordinateX, oldCell.CordinateY, maze);
                        ReplaceCell(newDecomposedCorpse, maze);
                        break;
                }

                cells.Remove(oldCell);
            }

            return maze;
        }

        //метод находть ближайшую клетку определенного типа к определенной координате,
        //которую представляет клетка переданная в метод.
        public BaseCell FindNearestCell<T>(BaseCell сell, string cellType, IMaze maze)
        where T : BaseCell
        {
            var startCell = сell;
            var differentTypeCells = new List<BaseCell>();
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
        public IEnumerable<BaseCell> GetNears(BaseCell cell, IMaze maze)
        {
            return GetNears<BaseCell>(cell, maze);
        }
        public IEnumerable<BaseCell> GetNears<CellType>(BaseCell cell, IMaze maze)
            where CellType : BaseCell
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
        public IEnumerable<BaseCell> GetNearsWhithDiagonals<CellType>(BaseCell cell, IMaze maze)
           where CellType : BaseCell
        {
            var NearestCell = GetNears<CellType>(cell, maze);
            var DiagonalCell = maze.Cells
                .Where(c =>
                    Math.Abs(c.CordinateX - cell.CordinateX) == 1 && Math.Abs(c.CordinateY - cell.CordinateY) == 1
                ).OfType<CellType>();
            var result = new List<BaseCell>();
            result.AddRange(NearestCell);
            result.AddRange(DiagonalCell);
            return result;
        }
        public T GetRandom<T>(List<T> data)
        {
            var index = _random.Next(data.Count);
            return data[index];
        }
        public IMaze ReplaceCell(BaseCell newCell, IMaze maze)
        {
            var oldCell = maze.Cells.Single(cell => cell.CordinateX == newCell.CordinateX && cell.CordinateY == newCell.CordinateY);
            maze.Cells.Remove(oldCell);
            maze.Cells.Add(newCell);
            return maze;
        }

        public BaseCell ReplaceCellToGround(BaseCell oldCell, IMaze maze)
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
