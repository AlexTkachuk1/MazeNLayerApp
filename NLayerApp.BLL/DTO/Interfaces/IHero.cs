using NLayerApp.BLL_.DTO.Items;

namespace NLayerApp.BLL_.DTO.Interfaces
{
    public interface IHero
    {
        int Gold { get; set; }
        IMaze Maze { get; set; }
        int X { get; set; }
        int Y { get; set; }
        int Damage { get; set; }
        int HP { get; set; }
        int Stamina { get; set; }

        List<BaseItem> Inventory { get; set; }
    }
}

