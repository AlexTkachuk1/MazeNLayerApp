using NLayerApp.BLL_.DTO.Interfaces;

namespace NLayerApp.BLL_.DTO.Cells
{
    public class SwampCreature : BaseCell
    {
        public SwampCreature(int x, int y, IMaze maze) : base(x, y, maze)
        {
        }

        public override bool TryStep()
        {
            throw new NotImplementedException();
        }
    }
}
