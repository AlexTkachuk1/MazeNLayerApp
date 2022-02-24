using NLayerApp.BLL_.DTO;
using NLayerApp.BLL_.DTO.Cells;
using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.BLL_.Interfaces;

namespace NLayerApp.BLL_.BusinessModels
{
    public class MazeBuilder
    {
        private IMaze _maze;

        private ICellsBuildService cellsBuildService;
        public MazeBuilder(
            ICellsBuildService cellsBuildService
            )
        {
            this.cellsBuildService = cellsBuildService;
        }

        public IMaze Build(int width = 30,
            int height = 15,
            Action<IMaze> drawStepByStep = null)
        {
            _maze = new MazeDTO()
            {
                Width = width,
                Height = height,
                Cells = new List<IBaseCell>(),
                DrawStepByStep = drawStepByStep
            };

            _maze = cellsBuildService.BuildWall(_maze);

            _maze = cellsBuildService.BuildGround(_maze);

            _maze = cellsBuildService.BuildGoldHeap(8, _maze);

            _maze = cellsBuildService.BuildGate(_maze);

            _maze = cellsBuildService.BuildAverageTreatmentPotion(5, _maze);

            _maze = cellsBuildService.BuildBagOfGold(5, _maze);

            _maze = cellsBuildService.BuildSmallPotionTreatment(5, _maze);

            _maze = cellsBuildService.BuildTrap(7, _maze);

            _maze = cellsBuildService.BuildLegionary(5, _maze);

            _maze = cellsBuildService.BuildBoss(1, _maze);

            _maze = cellsBuildService.BuildKiller(2,_maze);

            _maze = cellsBuildService.BuildTeleport(_maze);

            _maze = cellsBuildService.BuildMiracleShop(5, _maze);

            _maze = cellsBuildService.BuildСhest(10, _maze);

            _maze = cellsBuildService.BuildAverageTreatmentPotion(5, _maze);

            _maze = cellsBuildService.BuildBagOfGold(5, _maze);
            return _maze;
        }  
        public IMaze BuildCursedForest(int width = 30,
            int height = 15,
            Action<IMaze> drawStepByStep = null)
        {
            _maze = new MazeDTO()
            {
                Width = width,
                Height = height,
                Cells = new List<IBaseCell>(),
                DrawStepByStep = drawStepByStep
            };

            _maze = cellsBuildService.BuildWall(_maze);

            _maze = cellsBuildService.BuildGround(_maze);

            _maze = cellsBuildService.BuildGate(_maze);

            _maze = cellsBuildService.BuildGoldHeap(8, _maze);

            _maze = cellsBuildService.BuildInvisibleTrap(5, _maze);

            _maze = cellsBuildService.BuildAssassin(3, _maze);

            _maze = cellsBuildService.BuildChampion(1, _maze);

            _maze = cellsBuildService.BuildElf(3, _maze);

            _maze = cellsBuildService.BuildSwampCreature(6, _maze);

            _maze = cellsBuildService.BuildExperiencedWarrior(10, _maze);

            _maze = cellsBuildService.BuildRobot(5, _maze);

            _maze = cellsBuildService.BuildSmallPotionTreatment(3, _maze);

            _maze = cellsBuildService.BuildTeleport(_maze);

            _maze = cellsBuildService.BuildAverageTreatmentPotion(5, _maze);

            _maze = cellsBuildService.BuildBagOfGold(5, _maze);

            _maze = cellsBuildService.BuildMiracleShop(5, _maze);

            _maze = cellsBuildService.BuildСhest(20, _maze);

            return _maze;
        }

        public IMaze BuildPoisonSwamps(int width = 30,
            int height = 15,
            Action<IMaze> drawStepByStep = null)
        {
            _maze = new MazeDTO()
            {
                Width = width,
                Height = height,
                Cells = new List<IBaseCell>(),
                DrawStepByStep = drawStepByStep
            };

            _maze = cellsBuildService.BuildWall(_maze);

            _maze = cellsBuildService.BuildGround(_maze);

            _maze = cellsBuildService.BuildGate(_maze);

            _maze = cellsBuildService.BuildGoldHeap(8, _maze);

            _maze = cellsBuildService.BuildMutant(1, _maze);

            _maze = cellsBuildService.BuildDraconian(2, _maze);

            _maze = cellsBuildService.BuildDeadMan(3, _maze);

            _maze = cellsBuildService.BuildDecomposedCorpse(7, _maze);

            _maze = cellsBuildService.BuildDragon(1, _maze);

            _maze = cellsBuildService.BuildGoblin(3, _maze);

            _maze = cellsBuildService.BuildSmallPotionTreatment(3, _maze);

            _maze = cellsBuildService.BuildTeleport(_maze);

            _maze = cellsBuildService.BuildAverageTreatmentPotion(5, _maze);

            _maze = cellsBuildService.BuildBagOfGold(5, _maze);

            _maze = cellsBuildService.BuildMiracleShop(5, _maze);

            _maze = cellsBuildService.BuildСhest(20, _maze);

            _maze = cellsBuildService.BuildSwampCreature(3, _maze);

            return _maze;
        }
    }
}