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
        public int HP { get; set; }
        public int Stamina { get; set; }

        public List<BaseItem> Inventory { get; set; } = new List<BaseItem>();
    }
}
