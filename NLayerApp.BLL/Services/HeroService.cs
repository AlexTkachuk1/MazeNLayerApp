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
            return Database.Heroes.Get(3);
        }
        public void StepOnСhest()
        {
            var hero = GetHero();
            int val = _random.Next(1, 5);
            switch (val)
            {
                case 1:
                    var potionTreatment = new Item();
                    potionTreatment.Name = "PotionTreatment";
                    potionTreatment.Hero = hero;
                    hero.Inventory.Add(potionTreatment);
                    break;
                case 2:
                    var invisibilityCap = new Item();
                    invisibilityCap.Name = "InvisibilityCap";
                    invisibilityCap.Hero = hero;
                    hero.Inventory.Add(invisibilityCap);
                    break;
                case 3:
                    var giganHammer = new Item();
                    giganHammer.Name = "GiganHammer";
                    giganHammer.Hero = hero;
                    hero.Inventory.Add(giganHammer);
                    break;
                case 4:
                    var jumperBoots = new Item();
                    jumperBoots.Name = "JumperBoots";
                    jumperBoots.Hero = hero;
                    hero.Inventory.Add(jumperBoots);
                    break;
            }
            useInventory();
            Database.Save();
        }
        public void StepOnWater()
        {

        }
        public void StepOnKiller()
        {
            var hero = GetHero();
            if (hero.Invisible)
            {
                hero.Invisible = false;
                Database.Save();
            }
            else
            {
                var trueDamage = 100;
                DealDamage(trueDamage);

            }
            Database.Save();
        }
        public void StepOnWall()
        {
            var hero = GetHero();
            if (hero.HasGiganHammer)
            {
                hero.HasGiganHammer = false;
            }
            else if (hero.CanJump > 0)
            {
                hero.CanJump--;
            }
            Database.Save();
        }

        public void StepOnTrap()
        {
            var hero = GetHero();
            var damage = _random.Next(10, 15);
            DealDamage(damage);
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
            if (hero.Invisible)
            {
                hero.Invisible = false;
                Database.Save();
            }
            else
            {
                var gold = _random.Next(15, 30);
                hero.Gold += gold;
                if (hero.Damage > 0)
                {
                    hero.Damage--;
                    UpdateHero(hero);
                }
                else
                {
                    var damage = _random.Next(20, 50);
                    var allDamage = (damage - hero.Armor);
                    DealDamage(allDamage);
                }

            }
        }
        public void StepOnRip()
        {

        }
        public void StepOnMiracleShop(string cellTypeName)
        {
            var hero = GetHero();
            var item = new Item();
            switch (cellTypeName)
            {
                case "PotionTreatment":
                    hero.Gold -= 50;
                    if (hero.HP + 50 > 100)
                    {
                        hero.HP = 100;
                    }
                    else
                    {
                        hero.HP += 50;
                    }
                    break;
                case "InvisibilityCap":
                    hero.Gold -= 60;
                    item.Name = "InvisibilityCap";
                    break;
                case "GiganHammer":
                    hero.Gold -= 70;
                    item.Name = "GiganHammer";
                    break;
                case "JumperBoots":
                    hero.Gold -= 100;
                    item.Name = "JumperBoots";
                    break;
            }
            hero.Inventory.Add(item);
            useInventory();
            UpdateHero(hero);
        }
        public void StepOnBoss()
        {
            var hero = GetHero();
            if (hero.Invisible)
            {
                hero.Invisible = false;
                Database.Save();
            }
            else
            {
                var gold = _random.Next(10, 50);
                hero.Gold += gold;
                var trueDamage = 50;
                if (trueDamage >= hero.HP)
                {
                    hero.GameOver = true;
                    Database.Save();
                }
                hero.HP -= trueDamage;
                UpdateHero(hero);

                if (hero.Damage > 0)
                {
                    hero.Damage--;
                    UpdateHero(hero);
                }
                else
                {
                    var damage = _random.Next(20, 60);
                    var allDamage = (damage - hero.Armor);
                    DealDamage(allDamage);
                }
                int val = _random.Next(1, 3);
                var item = new Item();
                switch (val)
                {
                    case 1:
                        item.Name = "Shield";
                        break;
                    case 2:
                        item.Name = "Sword";
                        break;
                }
                hero.Inventory.Add(item);
                item.Hero = hero;
                useInventory();
                Database.Save();


            }
        }
        public void DealDamage(int damage)
        {
            var hero = GetHero();
            if (damage > 0)
            {
                if (damage >= hero.HP)
                {
                    hero.GameOver = true;
                    Database.Save();
                }
                hero.HP -= damage;
                UpdateHero(hero);
            }
        }
        public void StepOnGoldHeap()
        {
            var hero = GetHero();
            var gold = _random.Next(1, 5);
            hero.Gold += gold;
            UpdateHero(hero);
        }
        public void StepOnTeleport()
        {

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
            hero.Invisible = false;
            hero.HasGiganHammer = false;
            hero.CanJump = 0;
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
                    case "Shield":
                        hero.Armor += 15;
                        inventory.Remove(item);
                        break;
                    case "Sword":
                        hero.Damage += 1;
                        inventory.Remove(item);
                        break;
                    case "PotionTreatment":
                        if (hero.HP + 50 > 100)
                        {
                            hero.HP = 100;
                        }
                        else
                        {
                            hero.HP += 50;
                        }
                        inventory.Remove(item);
                        break;
                    case "InvisibilityCap":
                        hero.Invisible = true;
                        inventory.Remove(item);
                        break;
                    case "GiganHammer":
                        hero.HasGiganHammer = true;
                        inventory.Remove(item);
                        break;
                    case "JumperBoots":
                        hero.CanJump += 3;
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