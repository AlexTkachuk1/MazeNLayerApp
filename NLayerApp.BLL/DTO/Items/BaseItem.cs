using NLayerApp.BLL_.DTO.Interfaces;

namespace NLayerApp.BLL_.DTO.Items
{
    public abstract class BaseItem
    {
        public string Name { get; set; }
        public IHero Hero { get; set; }
        public IMaze Maze { get; set; }

        public BaseItem(IHero hero,IMaze maze)
        {
            Hero = hero;
            Maze = maze;
        }

        public abstract bool UseItem();
    }
}
