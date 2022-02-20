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
        public int Armor { get; set; }
        public bool GameOver { get; set; }
        public int Invisible { get; set; }
        public int HasGiganHammer { get; set; }
        public int CanJump { get; set; }
        public List<ItemViewModel> Inventory { get; set; } = new List<ItemViewModel>();
    }
}
