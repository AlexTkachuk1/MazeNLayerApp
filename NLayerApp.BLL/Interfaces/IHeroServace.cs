using NLayerApp.DAL_.Entities;

namespace NLayerApp.BLL_.Interfaces
{
    public interface IHeroService
    {
        Hero GetHero();
        void UpdateHero(Hero hero);
        void StepOnСhest();
        void StepOnGoldHeap();
        void StepOnWater();
        void StepOnTrap();
        void StepOnGate();
        void BrokenTrap();
        void ReturnDefaultHeroStatus();
        void Dispose();
    }
}
