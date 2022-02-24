using NLayerApp.BLL_.DTO.Interfaces;

namespace NLayerApp.BLL_.Interfaces
{
    public interface ICellsBuildService
    {
        IMaze BuildWall(IMaze maze);
        IMaze BuildGround(IMaze maze);
        IMaze BuildGroundMyVersion(IMaze maze);
        IMaze BuildLegionary(int chance, IMaze maze);
        IMaze BuildGate(IMaze maze);
        IMaze BuildPortal(int chance, IMaze maze);
        IMaze BuildSpiritOfTheForest(int chance, IMaze maze);
        IMaze BuildGuard(int chance, IMaze maze);
        IMaze BuildForgottenKing(int number, IMaze maze);
        IMaze BuildWolf(int chance, IMaze maze);
        IMaze BuildFaun(int chanceFrom1000, IMaze maze);
        IMaze BuildGoldHeap(int chance, IMaze maze);
        IMaze BuildAssassin(int chance, IMaze maze);
        IMaze BuildAverageTreatmentPotion(int chanceFrom1000, IMaze maze);
        IMaze BuildBagOfGold(int chanceFrom1000, IMaze maze);
        IMaze BuildChampion(int number, IMaze maze);
        IMaze BuildDamnEarth(int chance, IMaze maze);
        IMaze BuildDeadMan(int chance, IMaze maze);
        IMaze BuildDecomposedCorpse(int chance, IMaze maze);
        IMaze BuildDraconian(int chance, IMaze maze);
        IMaze BuildDragon(int number, IMaze maze);
        IMaze BuildElf(int chance, IMaze maze);
        IMaze BuildExperiencedWarrior(int chanceFrom1000, IMaze maze);
        IMaze BuildGoblin(int chance, IMaze maze);
        IMaze BuildMutant(int chance, IMaze maze);
        IMaze BuildRobot(int chanceFrom1000, IMaze maze);
        IMaze BuildSmallPotionTreatment(int chance, IMaze maze);
        IMaze BuildSwampCreature(int chance, IMaze maze);
        IMaze BuildTrap(int chance, IMaze maze);
        IMaze BuildBoss(int number, IMaze maze);
        IMaze BuildСhest(int chanceFrom1000, IMaze maze);
        IMaze BuildMiracleShop(int chanceFrom1000, IMaze maze);
        IMaze BuildKiller(int number, IMaze maze);
        IMaze BuildTeleport(IMaze maze);
        IMaze BuildInvisibleTrap(int chance, IMaze maze);
        void ConsoleDrawer(IMaze maze);

    }
}
