using NLayerApp.BLL_.DTO.Interfaces;

namespace NLayerApp.BLL_.DTO.Items
{
    public abstract class BaseItem
    {
        public IHero Hero { get; set; }

        public BaseItem(IHero hero)
        {
            Hero = hero;
        }
    }
}
