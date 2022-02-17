namespace NLayerApp.DAL_.Entities
{
    public class Maze
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public virtual List<Cell> Cells { get; set; }
        public virtual Hero Hero { get; set; }

    }
}