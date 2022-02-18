using AutoMapper;
using NLayerApp.BLL_.DTO;
using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.BLL_.DTO.Items;
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
            return Database.Heroes.Get(3);
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
            var damage = _random.Next(10, 20);
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
        public void StepOnLegionary()
        {
            var hero = GetHero();
            var gold = _random.Next(15, 30);
            hero.Gold += gold;
            if (hero.Damage>0)
            {
                hero.Damage--;
                UpdateHero(hero);
            }
            else
            {
                var damage = _random.Next(20, 50);
                var allDamage = (damage - hero.Armor);
                if (allDamage > hero.HP)
                {
                    hero.GameOver = true;
                    Database.Save();
                }
                else
                {
                    if (allDamage > 0)
                    {
                        hero.HP -= allDamage;
                    }
                    UpdateHero(hero);
                }
            }
        }
        public void StepOnRip()
        {

        }
        public void StepOnBoss()
        {
            var hero = GetHero();
            var gold = _random.Next(10, 50);
            hero.Gold += gold;
            if (hero.Damage > 0)
            {
                hero.Damage--;
                UpdateHero(hero);
            }
            else
            {
                var damage = _random.Next(30, 70);
                var allDamage = (damage - hero.Armor);
                if (allDamage > hero.HP)
                {
                    hero.GameOver = true;
                    Database.Save();
                }
                else
                {
                    if (allDamage > 0)
                    {
                        hero.HP -= allDamage;
                    }
                    UpdateHero(hero);
                }
            }
            switch (_random.Next(1, 3))
            {
                case 1:
                    var shield = new Item();
                    shield.Name = "Shield";
                    shield.Hero = hero;
                    hero.Inventory.Add(shield);
                    break;
                case 2:
                    var sword = new Item();
                    sword.Name = "Sword";
                    sword.Hero = hero;
                    hero.Inventory.Add(sword);
                    break;
            }
            useInventory();
            Database.Save();
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
            for (int i = 0; i < hero.Inventory.Count; i++)
            {
                hero.Inventory.Remove(hero.Inventory[i]);
            }
            hero.Gold = 0;
            hero.Damage = 0;
            hero.Armor = 0;
            Database.Heroes.Update(hero);
        }
        public void useInventory()
        {
            var hero = GetHero();
            var inventory = hero.Inventory;
            for (int i = 0; i < inventory.Count; i++)
            {
                var item = inventory[i];
                switch (item.Name)
                {
                    case"Shield":
                        hero.Armor += 10;
                        inventory.Remove(item);
                        break;
                    case "Sword":
                        hero.Damage += 2;
                        inventory.Remove(item);
                        break;
                }
            }
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}