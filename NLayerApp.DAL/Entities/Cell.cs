namespace NLayerApp.DAL_.Entities
{
    public class Cell
    {
        public int Id { get; set; }
        public int CordinateX { get; set; }
        public int CordinateY { get; set;}
        public string TypeName { get; set; }
        public virtual Maze Maze { get; set; }
    }
}
