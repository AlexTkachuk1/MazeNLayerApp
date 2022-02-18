namespace NLayerApp.DAL_.Entities
{
    public class Hero 
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Damage { get; set; }
        public int Gold { get; set; }
        public int HP { get; set; }
        public int Stamina { get; set; }
        public bool GameOver { get; set; }
        public virtual int MazeId { get; set; }
        public virtual Maze Maze { get; set; }
        public virtual List<Item> Inventory { get; set; }
    }
}