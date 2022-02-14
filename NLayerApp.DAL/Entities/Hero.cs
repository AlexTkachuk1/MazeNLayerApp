namespace NLayerApp.DAL_.Entities
{
    public class Hero 
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Maze Maze { get; set; }
        public int Damage { get; set; }
        public int Gold { get; set; }
        public int HP { get; set; }
        public int Stamina { get; set; }

        public List<string> Inventory { get; set; }
    }
}