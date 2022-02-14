namespace NLayerApp.WEB.Models
{
    public class UserViewModel
    {
        public string Login { get; set; }
        public ICollection<MazeViewModel> Mazes { get; set; }
    }
}
