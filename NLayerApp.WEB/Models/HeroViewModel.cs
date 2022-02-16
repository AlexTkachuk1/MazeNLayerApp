namespace NLayerApp.WEB.Models
{
    public class HeroViewModel
    {
        public int CordinateX { get; set; }
        public int CordinateY { get; set; }
        public int Damage { get; set; }
        public int Gold { get; set; }
        public int HP { get; set; }
        public int Stamina { get; set; }
        public List<ItemViewModel> Inventory { get; set; } = new List<ItemViewModel>();
    }
}
