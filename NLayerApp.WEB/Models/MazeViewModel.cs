using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NLayerApp.WEB.Models
{
    public class MazeViewModel
    {
        [Required]
        [DisplayName("Название")]
        public string Title { get; set; }

        [Range(3,20)]
        [DisplayName("Ширина")]
        public int Width { get; set; }

        [Range(3, 20)]
        [DisplayName("Высота")]
        public int Height { get; set; }
    }
}
