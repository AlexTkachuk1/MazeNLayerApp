using AutoMapper;
using NLayerApp.BLL_.Interfaces;
using NLayerApp.DAL_.Entities;
using NLayerApp.DAL_.Interfaces;

namespace NLayerApp.BLL_.Services
{
    public class HeroService : IHeroService
    {
        private Random _random = new Random();
        IUnitOfWork Database { get; set; }
        public readonly IMapper mapper;
        public HeroService(
            IMapper mapper,
            IUnitOfWork uow)
        {
            Database = uow;
            this.mapper = mapper;
        }
        public Hero GetHero()
        {
            return Database.Heroes.Get(2);
        }
        public void StepOnСhest()
        {

        }
        public void StepOnWater()
        {

        }
        public void StepOnTrap()
        {
            var hero = GetHero();
            var damage = _random.Next(20, 50);
            if (damage> hero.HP)
            {
                hero.GameOver = true;
                Database.Save();
            }
            else
            {
                hero.HP -= damage;
                UpdateHero(hero);
            }
        }
        public void StepOnGate()
        {

        }
        public void BrokenTrap()
        {

        }
        public void StepOnGoldHeap()
        {
            var hero = GetHero();
            var gold = _random.Next(1, 10);
            hero.Gold += gold;
            UpdateHero(hero);
        }
        public void SaveHero(Hero hero)
        {
            Database.Heroes.Create(hero);
        }
        public void UpdateHero(Hero hero)
        {
            Database.Heroes.Update(hero);
        }
        public void ReturnDefaultHeroStatus()
        {
            var hero = GetHero();
            hero.HP = 100;
            hero.GameOver = false;
            hero.X = 0;
            hero.Y = 0;
            hero.Stamina = 0;
            hero.Inventory = new List<Item>();
            hero.Gold = 0;
            hero.Damage = 0;
            Database.Heroes.Update(hero);
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}