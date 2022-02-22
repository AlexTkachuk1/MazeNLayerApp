using NLayerApp.BLL_.DTO.Cells;
using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.BLL_.Interfaces;
namespace NLayerApp.BLL_.Services
{
    public class CellsBuildService: ICellsBuildService
    {
        private IMazeBuildService _mazeBuildService;

        public CellsBuildService(
            IMazeBuildService mazeBuildService
            )
        {
            _mazeBuildService = mazeBuildService;
        }
        //Метод вызывать только после построения всех остальных клеток иначе его вызов приведет к ошибке.
        public IMaze BuildDamnEarth(int chance, IMaze maze)
        {
            var allGrounCell = maze.Cells.OfType<Ground>().ToList();
            for (int i = 0; i < allGrounCell.Count; i++)
            {
                var oldCell = allGrounCell[i];
                var newCell = new DamnEarth(oldCell.CordinateX, oldCell.CordinateY, maze);
                _mazeBuildService.ReplaceCell(newCell, maze);
            }
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildWall(IMaze maze)
        {
            for (int y = 0; y < maze.Height; y++)
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

            var randomCell = _mazeBuildService.GetRandom(maze.Cells);
            var wallsToDestroy = new List<BaseCell>()
            {
                //randomCell
            };
            var startCell = maze.Cells.Single(x => x.CordinateX == 0 && x.CordinateY == 0);
            wallsToDestroy.Add(startCell);
            maze.Hero.X = startCell.CordinateX;
            maze.Hero.Y = startCell.CordinateY;


            while (wallsToDestroy.Any())
            {
                ConsoleDrawer(maze);

                var wallToDestroy = _mazeBuildService.GetRandom(wallsToDestroy);

                var newGraundCell = _mazeBuildService.ReplaceCellToGround(wallToDestroy, maze);
                wallsToDestroy.Remove(wallToDestroy);

                var nearestWalls = _mazeBuildService.GetNears<Wall>(newGraundCell, maze);

                wallsToDestroy.AddRange(nearestWalls);

                wallsToDestroy = wallsToDestroy
                    .Where(wall => _mazeBuildService.GetNears<Ground>(wall, maze).Count() < 2)
                    .ToList();
            }
            return maze;
        }
        public IMaze BuildInvisibleTrap(int chans, IMaze maze)
        {
            _mazeBuildService.generateWithChance(chans, "InvisibleTrap", maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildLegionary(int chans, IMaze maze)
        {
            _mazeBuildService.generateWithChance(chans, "Legionary", maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildGate(IMaze maze)
        {
            var lastCell = maze.Cells.Single(cell => cell.CordinateY == maze.Height - 1
            && cell.CordinateX == maze.Width - 1);
            var cell = _mazeBuildService.FindNearestCell<Ground>(lastCell, "Ground", maze);
            var gateCell = new Gate(cell.CordinateX, cell.CordinateY, maze);
            _mazeBuildService.ReplaceCell(gateCell, maze);
            ConsoleDrawer(maze);
            return maze;
        }

        public IMaze BuildGoldHeap(int chance, IMaze maze)
        {
            _mazeBuildService.generateWithChance(chance, "GoldHeap", maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildAssassin(int chance, IMaze maze)
        {
            _mazeBuildService.generateWithChance(chance, "Assassin", maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildElf(int chance, IMaze maze)
        {
            _mazeBuildService.generateWithChance(chance, "Elf", maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildGoblin(int chance, IMaze maze)
        {
            _mazeBuildService.generateWithChance(chance, "Goblin", maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildMutant(int chance, IMaze maze)
        {
            _mazeBuildService.generateWithChance(chance, "Mutant", maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildSmallPotionTreatment(int chance, IMaze maze)
        {
            _mazeBuildService.generateWithChance(chance, "SmallPotionTreatment", maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildSwampCreature(int chance, IMaze maze)
        {
            _mazeBuildService.generateWithChance(chance, "SwampCreature", maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildRobot(int chanceFrom1000, IMaze maze)
        {
            var allGroundCells = maze.Cells.OfType<Wall>().ToList();
            var allCells = new List<BaseCell>();
            allCells.AddRange(allGroundCells);
            _mazeBuildService.generateWithTrueChance(chanceFrom1000, "Robot", allCells, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildExperiencedWarrior(int chanceFrom1000, IMaze maze)
        {
            var allGroundCells = maze.Cells.OfType<Wall>().ToList();
            var allCells = new List<BaseCell>();
            allCells.AddRange(allGroundCells);
            _mazeBuildService.generateWithTrueChance(chanceFrom1000, "ExperiencedWarrior", allCells, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildDecomposedCorpse(int chance, IMaze maze)
        {
            _mazeBuildService.generateWithChance(chance, "DecomposedCorpse", maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildDeadMan(int chance, IMaze maze)
        {
            _mazeBuildService.generateWithChance(chance, "DeadMan", maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildDraconian(int chance, IMaze maze)
        {
            _mazeBuildService.generateWithChance(chance, "Draconian", maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildAverageTreatmentPotion(int chanceFrom1000, IMaze maze)
        {
            var allGroundCells = maze.Cells.OfType<Wall>().ToList();
            var allCells = new List<BaseCell>();
            allCells.AddRange(allGroundCells);
            _mazeBuildService.generateWithTrueChance(chanceFrom1000, "AverageTreatmentPotion", allCells, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildBagOfGold(int chanceFrom1000, IMaze maze)
        {
            var allGroundCells = maze.Cells.OfType<Wall>().ToList();
            var allCells = new List<BaseCell>();
            allCells.AddRange(allGroundCells);
            _mazeBuildService.generateWithTrueChance(chanceFrom1000, "BagOfGold", allCells, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildChampion(int number, IMaze maze)
        {
            var graundCells = maze.Cells.OfType<Ground>().ToList();
            var allGraundCells = new List<BaseCell>();
            allGraundCells.AddRange(graundCells);
            _mazeBuildService.generateTheNumberOfCells(number, "Champion", allGraundCells, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildDragon(int number, IMaze maze)
        {
            var graundCells = maze.Cells.OfType<Ground>().ToList();
            var allGraundCells = new List<BaseCell>();
            allGraundCells.AddRange(graundCells);
            _mazeBuildService.generateTheNumberOfCells(number, "Dragon", allGraundCells, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildTrap(int chance, IMaze maze)
        {
            _mazeBuildService.generateWithChance(chance, "Trap", maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildBoss(int number, IMaze maze)
        {
            var graundCells = maze.Cells.OfType<Ground>().ToList();
            var allGraundCells = new List<BaseCell>();
            allGraundCells.AddRange(graundCells);
            _mazeBuildService.generateTheNumberOfCells(number, "Boss", allGraundCells, maze);
            ConsoleDrawer(maze);
            return maze;
        }

        public IMaze BuildСhest(int chanceFrom1000, IMaze maze)
        {
            var allGroundCells = maze.Cells.OfType<Ground>().ToList();
            var allCells = new List<BaseCell>();
            allCells.AddRange(allGroundCells);
            _mazeBuildService.generateWithTrueChance(chanceFrom1000, "Сhest", allCells, maze);
            ConsoleDrawer(maze);
            return maze;
        }

        public IMaze BuildMiracleShop(int chanceFrom1000, IMaze maze)
        {
            var allGroundCells = maze.Cells.OfType<Wall>().ToList();
            var allCells = new List<BaseCell>();
            allCells.AddRange(allGroundCells);
            _mazeBuildService.generateWithTrueChance(chanceFrom1000, "MiracleShop", allCells, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildKiller(int number, IMaze maze)
        {
            var graundCells = maze.Cells.OfType<Ground>().ToList();
            var allGraundCells = new List<BaseCell>();
            allGraundCells.AddRange(graundCells);
            _mazeBuildService.generateTheNumberOfCells(number, "Killer", allGraundCells, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildTeleport(IMaze maze)
        {
            var graundCells = maze.Cells.OfType<Ground>().ToList();
            var allGraundCells = new List<BaseCell>();
            allGraundCells.AddRange(graundCells);
            _mazeBuildService.generateTheNumberOfCells(2, "Teleport", allGraundCells, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public void ConsoleDrawer(IMaze maze)
        {
            if (maze.DrawStepByStep != null)
            {
                maze.DrawStepByStep.Invoke(maze);
                //Thread.Sleep(100);
            }
        }
    }
}
