using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.BLL_.DTO.Items;

namespace NLayerApp.BLL_.DTO
{
    public class HeroSingleton : IHero
    {
        private static HeroSingleton instance;

        private HeroSingleton() { }

        public static HeroSingleton GetHero()
        {
            if (instance == null)
            {
                instance = new HeroSingleton();
            }
            return instance;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public IMaze Maze { get; set; }
        public int Damage { get; set; }
        public int Gold { get; set; }
        public int HP { get; set; } = 100;
        public int Stamina { get; set; }
        public int Armor { get; set; }
        public bool  GameOver { get; set; } = false;
        public int Invisible { get; set; }
        public int HasGiganHammer { get; set; }
        public int CanJump { get; set; } 
        public List<BaseItem> Inventory { get; set; } = new List<BaseItem>();
    }
}
