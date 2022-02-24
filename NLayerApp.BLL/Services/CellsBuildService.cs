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
        public IMaze BuildEnvironment(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

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
            var wallsToDestroy = new List<IBaseCell>()
            {
                //randomCell
            };
            var startCell = maze.Cells.Single(x => x.CordinateX == 1 && x.CordinateY == 1);
            wallsToDestroy.Add(startCell);
            maze.Hero.X = startCell.CordinateX;
            maze.Hero.Y = startCell.CordinateY;


            while (wallsToDestroy.Any())
            {
                ConsoleDrawer(maze);

                var wallToDestroy = _mazeBuildService.GetRandom(wallsToDestroy);

                var newGraundCell = _mazeBuildService.ReplaceCellToGround(wallToDestroy, maze);
                wallsToDestroy.Remove(wallToDestroy);

                var nearestWalls = _mazeBuildService.GetNears<Wall>(newGraundCell, maze)
                    .Where(x=>x.CordinateX !=0
                    && x.CordinateX < maze.Width-1 
                    && x.CordinateY != 0
                    && x.CordinateY < maze.Height-1);

                wallsToDestroy.AddRange(nearestWalls);

                wallsToDestroy = wallsToDestroy
                    .Where(wall => _mazeBuildService.GetNears<Ground>(wall, maze).Count() < 2)
                    .ToList();
            }
            return maze;
        }
        public IMaze BuildGroundMyVersion(IMaze maze)
        {
            var wallsToDestroy = new List<IBaseCell>() {
                maze.Cells[0]
            };

            var cellVisited = new List<IBaseCell>();
            var allWallsToDestroy = wallsToDestroy;
            while (wallsToDestroy.Any() && allWallsToDestroy.Any())
            {
                
                if (wallsToDestroy.Any())
                {
                    var ToDestroy = _mazeBuildService.GetRandom(wallsToDestroy);
                    allWallsToDestroy.Remove(ToDestroy);

                    var ground = _mazeBuildService.ReplaceCellToGround(ToDestroy, maze);
                    wallsToDestroy.Remove(ToDestroy);

                    cellVisited.Add(ground);
                    wallsToDestroy = new List<IBaseCell>();

                    var nearestWalls = _mazeBuildService.GetNears<Wall>(ground, maze);


                    wallsToDestroy.AddRange(nearestWalls);


                    wallsToDestroy = wallsToDestroy
                        .Where(wall => _mazeBuildService.GetNears<Ground>(wall, maze).Count() < 2)
                        .ToList();
                    wallsToDestroy = wallsToDestroy.Where(wall => _mazeBuildService.GetNearsWhithDiagonals<Ground>(wall, maze).Count() < 3)
                        .ToList();
                    allWallsToDestroy.AddRange(wallsToDestroy);
                    while (!wallsToDestroy.Any() && allWallsToDestroy.Any())
                    {
                        allWallsToDestroy = allWallsToDestroy.Where(wall => _mazeBuildService.GetNearsWhithDiagonals<Ground>(wall, maze).Count() < 3)
                        .ToList();
                        var randomCellVisited = _mazeBuildService.GetRandom(cellVisited);
                        var allNearestWalls = _mazeBuildService.GetNearsWhithDiagonals<Wall>(randomCellVisited, maze);
                        var newWallToDestroy = allNearestWalls.Where(wall => _mazeBuildService.GetNears<Ground>(wall, maze).Count() < 2)
                        .ToList();
                        if (newWallToDestroy.Any())
                        {
                            wallsToDestroy.Add(_mazeBuildService.GetRandom(newWallToDestroy));
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
        public IMaze BuildInvisibleTrap(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<InvisibleTrap>(cellsForReplace, maze);

            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildLegionary(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<Legionary>(cellsForReplace, maze);
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
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<GoldHeap>(cellsForReplace, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildAssassin(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<Assassin>(cellsForReplace, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildElf(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<Elf>(cellsForReplace, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildGoblin(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<Goblin>(cellsForReplace, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildMutant(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<Mutant>(cellsForReplace, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildSmallPotionTreatment(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<SmallPotionTreatment>(cellsForReplace, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildSwampCreature(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<SwampCreature>(cellsForReplace, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildRobot(int chanceFrom1000, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithTrueChance<Ground>(chanceFrom1000, maze);

            _mazeBuildService.generateCells<Robot>(cellsForReplace, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildExperiencedWarrior(int chanceFrom1000, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithTrueChance<Ground>(chanceFrom1000, maze);

            _mazeBuildService.generateCells<ExperiencedWarrior>(cellsForReplace, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildDecomposedCorpse(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<DecomposedCorpse>(cellsForReplace, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildDeadMan(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<DeadMan>(cellsForReplace, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildDraconian(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<Draconian>(cellsForReplace, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildAverageTreatmentPotion(int chanceFrom1000, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithTrueChance<Ground>(chanceFrom1000, maze);

            _mazeBuildService.generateCells<AverageTreatmentPotion>(cellsForReplace, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildBagOfGold(int chanceFrom1000, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithTrueChance<Ground>(chanceFrom1000, maze);

            _mazeBuildService.generateCells<BagOfGold>(cellsForReplace, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildChampion(int number, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateTheNumberOfCells<Ground>(number, maze);

            _mazeBuildService.generateCells<Champion>(cellsForReplace, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildDragon(int number, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateTheNumberOfCells<Ground>(number, maze);

            _mazeBuildService.generateCells<Dragon>(cellsForReplace, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildTrap(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<Trap>(cellsForReplace, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildBoss(int number, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateTheNumberOfCells<Ground>(number, maze);

            _mazeBuildService.generateCells<Boss>(cellsForReplace, maze);
            ConsoleDrawer(maze);
            return maze;
        }

        public IMaze BuildСhest(int chanceFrom1000, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithTrueChance<Ground>(chanceFrom1000, maze);

            _mazeBuildService.generateCells<Сhest>(cellsForReplace, maze);
            ConsoleDrawer(maze);
            return maze;
        }

        public IMaze BuildMiracleShop(int chanceFrom1000, IMaze maze)
        {
            var allTypeCells = _mazeBuildService.generateWithTrueChance<Wall>(chanceFrom1000, maze);

            var  cellsForReplace = allTypeCells.Where(x => x.CordinateX != 0
                    && x.CordinateX < maze.Width - 1
                    && x.CordinateY != 0
                    && x.CordinateY < maze.Height - 1).ToList();

            _mazeBuildService.generateCells<MiracleShop>(cellsForReplace, maze);
            ConsoleDrawer(maze);
            return maze;
        }
        public IMaze BuildKiller(int number, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateTheNumberOfCells<Ground>(number, maze);

            _mazeBuildService.generateCells<Killer>(cellsForReplace, maze);
            return maze;
        }
        public IMaze BuildTeleport(IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateTheNumberOfCells<Ground>(2, maze);

            _mazeBuildService.generateCells<Teleport>(cellsForReplace, maze);
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
