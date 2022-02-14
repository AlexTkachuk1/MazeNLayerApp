namespace NLayerApp.DAL_.Entities
{
    public class Maze
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public User Creater { get; set; }
        public List<Cell> Cells { get; set; }
        public Hero Hero { get; set; }

    }
}