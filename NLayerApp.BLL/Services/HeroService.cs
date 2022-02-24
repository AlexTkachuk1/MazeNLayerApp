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
        public void StepOn(string cellTypeName)
        {
            switch (cellTypeName)
            {
                case "Сhest":
                    StepOnСhest();
                    break;
                case "Water":
                    StepOnWater();
                    break;
                case "Trap":
                    StepOnTrap();
                    break;
                case "GoldHeap":
                    StepOnGoldHeap();
                    break;
                case "Gate":
                    StepOnGate();
                    break;
                case "BrokenTrap":
                    BrokenTrap();
                    break;
                case "Legionary":
                    StepOnLegionary();
                    break;
                case "Rip":
                    StepOnRip();
                    break;
                case "Boss":
                    StepOnBoss();
                    break;
                case "Wall":
                    StepOnWall();
                    break;
                case "Teleport":
                    StepOnTeleport();
                    break;
                case "Killer":
                    StepOnKiller();
                    break;
                case "InvisibleTrap":
                    StepOnInvisibleTrap();
                    break;
                case "Assassin":
                    StepOnAssassin();
                    break;
                case "AverageTreatmentPotion":
                    StepOnAverageTreatmentPotion();
                    break;
                case "BagOfGold":
                    StepOnBagOfGold();
                    break;
                case "Champion":
                    StepOnChampion();
                    break;
                case "DamnEarth":
                    StepOnDamnEarth();
                    break;
                case "DeadMan":
                    StepOnDeadMan();
                    break;
                case "DecomposedCorpse":
                    StepOnDecomposedCorpse();
                    break;
                case "Draconian":
                    StepOnDraconian();
                    break;
                case "Dragon":
                    StepOnDragon();
                    break;
                case "Elf":
                    StepOnElf();
                    break;
                case "ExperiencedWarrior":
                    StepOnExperiencedWarrior();
                    break;
                case "Goblin":
                    StepOnGoblin();
                    break;
                case "Mutant":
                    StepOnMutant();
                    break;
                case "Robot":
                    StepOnRobor();
                    break;
                case "SmallPotionTreatment":
                    StepOnSmallPotionTreatment();
                    break;
                case "SwampCreature":
                    StepOnSwampCreature();
                    break;
            }
        }
        public void StepOnSwampCreature()
        {
            var hero = GetHero();
            if (!CanUseDamage(hero)) 
            {
                var damage = _random.Next(15,30);
                var trueDamage = damage - hero.Armor;
                DealDamage(trueDamage);
            }
        }
        public void StepOnSmallPotionTreatment()
        {
            var hero = GetHero();
            var healingPower = _random.Next(10, 35);
            if(hero.HP+ healingPower <= 100)
            {
                hero.HP += healingPower;
            }
            else
            {
                hero.HP = 100;
            }
            UpdateHero(hero);
        }
        public void StepOnRobor()
        {
            var hero = GetHero();
            if (!CanStels(hero))
            {
                var trueDamage = _random.Next(4, 40);
                var armor = trueDamage / 2;
                hero.Armor += armor;
                DealDamage(trueDamage);
            }
        }
        public void StepOnMutant()
        {
            var hero = GetHero();
            var trueDamage = 20;
            if (hero.HP < 100)
            {
                trueDamage += (100 - hero.HP);
            }
            DealDamage(trueDamage);
        }
        public void StepOnGoblin()
        {
            var hero = GetHero();
            if (!CanStels(hero))
            {
                if (!CanUseDamage(hero))
                {
                    var damage = _random.Next(10, 20);
                    var trueDamage = damage - hero.Armor;
                    DealDamage(trueDamage);
                }
            }
        }
        public void StepOnExperiencedWarrior()
        {
            var hero = GetHero();
            if (hero.HP > 70)
            {
                var trueDamage = 30;
                if (hero.Damage > 0 || hero.Armor > 0)
                {
                    trueDamage += (hero.Armor + (hero.Damage * 3));
                }
                DealDamage(trueDamage);
            }
        }
        public void StepOnElf()
        {
            var hero = GetHero();
            if (!CanUseDamage(hero))
            {
                var trueDamage = 15;
                if (hero.CanJump > 0 || hero.HasGiganHammer > 0 || hero.Invisible > 0)
                {
                    var val = 5 * (hero.CanJump + hero.HasGiganHammer + hero.Invisible)+ hero.Armor/2;
                    
                    trueDamage += val;
                }
                DealDamage(trueDamage);
            }

        }
        public void StepOnDragon()
        {
            var hero = GetHero();
            var trueDamage = 90;
            if (hero.Gold > 100)
            {
                hero.Gold -= 100;
                UpdateHero(hero);
            }
            else
            {
                if (hero.Armor > 0 || hero.Damage > 0)
                {
                    trueDamage = trueDamage / 3;
                    hero.Armor = 0;
                    hero.Damage = 0;
                }
                DealDamage(trueDamage);
            }
        }
        public void StepOnDraconian()
        {
            var hero = GetHero();
            if (!CanStels(hero))
            {
                var trueDamage = 60;
                if (hero.Armor > 0 || hero.Damage > 0)
                {
                    trueDamage = trueDamage / 2;
                }
                var gold = trueDamage;
                hero.Gold += gold;
                DealDamage(trueDamage);
            }
        }
        public void StepOnDecomposedCorpse()
        {
            var trueDamage = _random.Next(5, 10);
            DealDamage(trueDamage);
        }
        public void StepOnDeadMan()
        {
            var hero = GetHero();
            if (!CanStels(hero))
            {
                if (!CanUseDamage(hero))
                {
                    var damage = _random.Next(20, 40);
                    var trueDamage = damage - (hero.Armor * 2);
                    DealDamage(trueDamage);
                }

            }
        }
        public void StepOnDamnEarth()
        {
            var trueDamage = 1;
            DealDamage(trueDamage);
        }
        public void StepOnChampion()
        {
            var hero = GetHero();
            if (!CanStels(hero))
            {
                var trueDamage = 80;
                var gold = 30;
                if (hero.Armor > 0)
                {
                    trueDamage -= hero.Armor;
                }
                hero.Armor = 0;
                if (hero.Damage > 0)
                {
                    for (int i = 0; i < hero.Damage; i++)
                    {
                        trueDamage -= 20;
                    }
                }
                hero.Damage = 0;
                if (hero.CanJump > 0)
                {
                    for (int i = 0; i < hero.CanJump; i++)
                    {
                        trueDamage -= 15;
                    }
                }
                hero.CanJump = 0;
                if (hero.HasGiganHammer > 0)
                {
                    for (int i = 0; i < hero.HasGiganHammer; i++)
                    {
                        trueDamage -= 20;
                    }
                }
                hero.HasGiganHammer = 0;
                if (trueDamage < 0)
                {
                    var goldBonus = trueDamage * -1 * 3;
                    gold += goldBonus;
                    hero.Gold += gold;
                    UpdateHero(hero);
                }
                DealDamage(trueDamage);
            }
        }
        public void StepOnBagOfGold()
        {
            var hero = GetHero();
            hero.Gold += _random.Next(10, 30);
            UpdateHero(hero);
        }
        public void StepOnAverageTreatmentPotion()
        {
            var hero = GetHero();
            hero.HP = 100;
            UpdateHero(hero);
        }
        public void StepOnAssassin()
        {
            var hero = GetHero();
            if (hero.Gold >= 60)
            {
                hero.Gold -= 60;
                hero.Damage += 1;
                UpdateHero(hero);
            }
            else
            {
                int trueDamage = 35;
                DealDamage(trueDamage);
            }
        }
        public void StepOnInvisibleTrap()
        {
            int trueDamage = _random.Next(1, 10);
            DealDamage(trueDamage);
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
            if (!CanStels(hero))
            {
                var trueDamage = 50;
                DealDamage(trueDamage);
            }
            Database.Save();
        }
        public void StepOnWall()
        {
            var hero = GetHero();
            if (hero.HasGiganHammer > 0)
            {
                hero.HasGiganHammer--;
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
            var trueDamage = damage - hero.Armor;

            if (trueDamage > 0)
            {
                DealDamage(trueDamage);
            }
            if (hero.HP + 5 > 100)
            {
                hero.HP = 100;
            }
            hero.HP += 5;
            Database.Save();
        }
        public void StepOnGate()
        {

        }
        public void BrokenTrap()
        {

        }
        public bool CanStels(Hero hero)
        {
            if (hero.Invisible > 0)
            {
                hero.Invisible--;
                Database.Save();
                return true;
            }
            return false;
        }
        public bool CanUseDamage(Hero hero)
        {
            if (hero.Damage > 0)
            {
                hero.Damage--;
                Database.Save();
                return true;
            }
            return false;
        }
        public void StepOnLegionary()
        {
            var hero = GetHero();
            if (!CanStels(hero))
            {
                var gold = _random.Next(15, 30);
                hero.Gold += gold;
                if (!CanUseDamage(hero))
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
                    if (ToBuy(50))
                    {
                        if (hero.HP + 50 > 100)
                        {
                            hero.HP = 100;
                        }
                        else
                        {
                            hero.HP += 50;
                        }
                    }
                    break;
                case "InvisibilityCap":
                    if (ToBuy(60))
                    {
                        item.Name = "InvisibilityCap";
                        hero.Inventory.Add(item);
                    }
                    break;
                case "GiganHammer":
                    if (ToBuy(70))
                    {
                        item.Name = "GiganHammer";
                        hero.Inventory.Add(item);
                    }
                    break;
                case "JumperBoots":
                    if (ToBuy(100))
                    {
                        item.Name = "JumperBoots";
                        hero.Inventory.Add(item);
                    }
                    break;
            }

            useInventory();
            UpdateHero(hero);
        }
        public bool ToBuy(int cost)
        {
            var hero = GetHero();
            if (hero.Gold - cost > 0)
            {
                hero.Gold -= cost;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void StepOnBoss()
        {
            var hero = GetHero();
            if (!CanStels(hero))
            {
                var gold = _random.Next(1, 30);
                hero.Gold += gold;
                var trueDamage = 40;
                if (trueDamage >= hero.HP)
                {
                    hero.GameOver = true;
                    Database.Save();
                }
                hero.HP -= trueDamage;
                UpdateHero(hero);

                if (!CanUseDamage(hero))
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
            }
            UpdateHero(hero);
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
            hero.Invisible = 0;
            hero.HasGiganHammer = 0;
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
                        hero.Damage += 2;
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
                        hero.Invisible += 2;
                        inventory.Remove(item);
                        break;
                    case "GiganHammer":
                        hero.HasGiganHammer += 2;
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