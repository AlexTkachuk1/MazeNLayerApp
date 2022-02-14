namespace NLayerApp.WEB.Models
{
    public class MazeViewModel
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<CellViewModel> Cells { get; set; }
    }
}
