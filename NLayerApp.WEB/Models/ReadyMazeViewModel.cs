namespace NLayerApp.WEB.Models
{
    public class ReadyMazeViewModel
    {
        public int MazeHeight { get; set; }
        public int MazeWidth { get; set; }
        public HeroViewModel Hero { get; set; }
        public List<CellViewModel> CellViewModels { get; set; } = new List<CellViewModel>();
    }
}
