using NLayerApp.BLL_.DTO.Cells;
using NLayerApp.BLL_.DTO.Cells.New;
using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.BLL_.Interfaces;
namespace NLayerApp.BLL_.Services
{
    public class CellsBuildService : ICellsBuildService
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
                //ConsoleDrawer(maze);

                var wallToDestroy = _mazeBuildService.GetRandom(wallsToDestroy);

                var newGraundCell = _mazeBuildService.ReplaceCellToGround(wallToDestroy, maze);
                wallsToDestroy.Remove(wallToDestroy);

                var nearestWalls = _mazeBuildService.GetNears<Wall>(newGraundCell, maze)
                    .Where(x => x.CordinateX != 0
                    && x.CordinateX < maze.Width - 1
                    && x.CordinateY != 0
                    && x.CordinateY < maze.Height - 1);

                wallsToDestroy.AddRange(nearestWalls);

                wallsToDestroy = wallsToDestroy
                    .Where(wall => _mazeBuildService.GetNears<Ground>(wall, maze).Count() < 2)
                    .ToList();
            }
            return maze;
        }
        public IMaze BuildTornado(int number, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateTheNumberOfCells<Ground>(number, maze);

            _mazeBuildService.generateCells<Tornado>(cellsForReplace, maze);

            return maze;
        }
        public IMaze BuildFaun(int chanceFrom1000, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithTrueChance<Ground>(chanceFrom1000, maze);

            _mazeBuildService.generateCells<Faun>(cellsForReplace, maze);

            return maze;
        }
        public IMaze BuildWolf(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<Wolf>(cellsForReplace, maze);

            return maze;
        }
        public IMaze BuildForgottenKing(int number, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateTheNumberOfCells<Ground>(number, maze);

            _mazeBuildService.generateCells<ForgottenKing>(cellsForReplace, maze);

            return maze;
        }
        // Сработает при вызове после создания портала.
        public IMaze BuildGuard(IMaze maze)
        {
            var portalCell = maze.Cells.OfType<Portal>().ToList();
            var cellsForReplace = new List<IBaseCell>();
            for (int i = 0; i < portalCell.Count; i++)
            {
                var cell = portalCell[i];   
                var cells = _mazeBuildService.GetNears<Ground>(cell, maze);
                cellsForReplace.AddRange(cells);
            }
             _mazeBuildService.generateCells<Guard>(cellsForReplace, maze);

            return maze;
        }
        public IMaze BuildSpiritOfTheForest(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<SpiritOfTheForest>(cellsForReplace, maze);

            return maze;
        }
        public IMaze BuildPortal(int number, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateTheNumberOfCells<Wall>(number, maze).Where(x => x.CordinateX != 0
                   && x.CordinateX < maze.Width - 1
                   && x.CordinateY != 0
                   && x.CordinateY < maze.Height - 1).ToList(); 

            _mazeBuildService.generateCells<Portal>(cellsForReplace, maze);

            return maze;
        }
        public IMaze BuildInvisibleTrap(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<InvisibleTrap>(cellsForReplace, maze);

            return maze;
        }
        public IMaze BuildLegionary(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<Legionary>(cellsForReplace, maze);
            return maze;
        }
        public IMaze BuildGates(IMaze maze)
        {
            var lastCell = maze.Cells.Single(cell => cell.CordinateY == maze.Height - 1
            && cell.CordinateX == maze.Width - 1);
            var cell = _mazeBuildService.FindNearestCell<Ground>(lastCell, "Ground", maze);
            var gateCell = new Gate(cell.CordinateX, cell.CordinateY, maze);
            _mazeBuildService.ReplaceCell(gateCell, maze);
            return maze;
        }

        public IMaze BuildGoldHeap(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<GoldHeap>(cellsForReplace, maze);
            return maze;
        }
        public IMaze BuildAssassin(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<Assassin>(cellsForReplace, maze);
            return maze;
        }
        public IMaze BuildElf(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<Elf>(cellsForReplace, maze);
            return maze;
        }
        public IMaze BuildGoblin(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<Goblin>(cellsForReplace, maze);
            return maze;
        }
        public IMaze BuildMutant(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<Mutant>(cellsForReplace, maze);
            return maze;
        }
        public IMaze BuildSmallPotionTreatment(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<SmallPotionTreatment>(cellsForReplace, maze);
            return maze;
        }
        public IMaze BuildSwampCreature(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<SwampCreature>(cellsForReplace, maze);
            return maze;
        }
        public IMaze BuildRobot(int chanceFrom1000, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithTrueChance<Ground>(chanceFrom1000, maze);

            _mazeBuildService.generateCells<Robot>(cellsForReplace, maze);
            return maze;
        }
        public IMaze BuildExperiencedWarrior(int chanceFrom1000, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithTrueChance<Ground>(chanceFrom1000, maze);

            _mazeBuildService.generateCells<ExperiencedWarrior>(cellsForReplace, maze);
            return maze;
        }
        public IMaze BuildDecomposedCorpse(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<DecomposedCorpse>(cellsForReplace, maze);
            return maze;
        }
        public IMaze BuildDeadMan(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<DeadMan>(cellsForReplace, maze);
            return maze;
        }
        public IMaze BuildDraconian(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<Draconian>(cellsForReplace, maze);
            return maze;
        }
        public IMaze BuildAverageTreatmentPotion(int chanceFrom1000, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithTrueChance<Ground>(chanceFrom1000, maze);

            _mazeBuildService.generateCells<AverageTreatmentPotion>(cellsForReplace, maze);
            return maze;
        }
        public IMaze BuildBagOfGold(int chanceFrom1000, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithTrueChance<Ground>(chanceFrom1000, maze);

            _mazeBuildService.generateCells<BagOfGold>(cellsForReplace, maze);
            return maze;
        }
        public IMaze BuildChampion(int number, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateTheNumberOfCells<Ground>(number, maze);

            _mazeBuildService.generateCells<Champion>(cellsForReplace, maze);
            return maze;
        }
        public IMaze BuildDragon(int number, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateTheNumberOfCells<Ground>(number, maze);

            _mazeBuildService.generateCells<Dragon>(cellsForReplace, maze);
            return maze;
        }
        public IMaze BuildTrap(int chance, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithChance<Ground>(chance, maze);

            _mazeBuildService.generateCells<Trap>(cellsForReplace, maze);
            return maze;
        }
        public IMaze BuildBoss(int number, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateTheNumberOfCells<Ground>(number, maze);

            _mazeBuildService.generateCells<Boss>(cellsForReplace, maze);
            return maze;
        }

        public IMaze BuildСhest(int chanceFrom1000, IMaze maze)
        {
            var cellsForReplace = _mazeBuildService.generateWithTrueChance<Ground>(chanceFrom1000, maze);

            _mazeBuildService.generateCells<Сhest>(cellsForReplace, maze);
            return maze;
        }

        public IMaze BuildMiracleShop(int chanceFrom1000, IMaze maze)
        {
            var allTypeCells = _mazeBuildService.generateWithTrueChance<Wall>(chanceFrom1000, maze);

            var cellsForReplace = allTypeCells.Where(x => x.CordinateX != 0
                   && x.CordinateX < maze.Width - 1
                   && x.CordinateY != 0
                   && x.CordinateY < maze.Height - 1).ToList();

            _mazeBuildService.generateCells<MiracleShop>(cellsForReplace, maze);
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
            return maze;
        }
    }
}
