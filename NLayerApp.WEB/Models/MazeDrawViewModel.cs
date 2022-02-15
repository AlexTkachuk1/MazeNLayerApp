namespace NLayerApp.WEB.Models
{
    public class MazeDrawViewModel
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string[,] Cells { get; set; }
    }
}
