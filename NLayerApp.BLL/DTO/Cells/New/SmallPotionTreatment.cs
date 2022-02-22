using NLayerApp.BLL_.DTO.Interfaces;

namespace NLayerApp.BLL_.DTO.Cells
{
    public class SmallPotionTreatment : BaseCell
    {
        public SmallPotionTreatment(int x, int y, IMaze maze) : base(x, y, maze)
        {
        }

        public override bool TryStep()
        {
            throw new NotImplementedException();
        }
    }
}
