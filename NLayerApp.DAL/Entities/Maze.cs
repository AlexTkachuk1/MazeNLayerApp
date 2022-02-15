namespace NLayerApp.DAL_.Entities
{
    public class Maze
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Id { get; set; }
        public virtual List<Cell> Cells { get; set; }
        public virtual User Creater { get; set; }
        public virtual Hero Hero { get; set; }

    }
}