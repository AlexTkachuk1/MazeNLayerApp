using NLayerApp.DAL_.Entities;

namespace NLayerApp.BLL_.Interfaces
{
    public interface IHeroService
    {
        Hero GetHero();
        void StepOn(string cellTypeName);
        void StepOnSwampCreature();
        void StepOnSmallPotionTreatment();
        void StepOnRobor();
        void StepOnMutant();
        void StepOnGoblin();
        void StepOnExperiencedWarrior();
        void StepOnElf();
        void StepOnDragon();
        void StepOnDraconian();
        void StepOnDecomposedCorpse();
        void StepOnDeadMan();
        void StepOnDamnEarth();
        void StepOnChampion();
        void StepOnBagOfGold();
        void StepOnAverageTreatmentPotion();
        void StepOnAssassin();
        void UpdateHero(Hero hero);
        void StepOnСhest();
        void StepOnGoldHeap();
        void StepOnWater();
        void StepOnTrap();
        void StepOnGate();
        void BrokenTrap();
        void StepOnLegionary();
        void StepOnRip();
        void StepOnBoss();
        void StepOnWall();
        void StepOnTeleport();
        void StepOnMiracleShop(string cellTypeName);
        void StepOnKiller();
        void ReturnDefaultHeroStatus();
        void StepOnPortal(int damage);
        void StepOnSpiritOfTheForest(int damageMin, int damageMax);
        void StepOnGuard(int damageMin, int damageMax);
        void StepOnForgottenKing(int damageMin, int damageMax);
        void StepOnWolf(int spiritDamage, int physicalDamage);
        void StepOnFaun();
        void Dispose();
    }
}