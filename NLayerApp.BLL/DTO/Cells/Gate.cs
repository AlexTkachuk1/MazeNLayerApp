using NLayerApp.BLL_.BusinessModels;
using NLayerApp.BLL_.DTO.Interfaces;

namespace NLayerApp.BLL_.DTO.Cells
{
    public class Gate: BaseCell
    {
        public Gate(int x, int y, IMaze maze) : base(x, y, maze)
        {
        }

        public override bool TryStep()
        {
            return true;
        }
    }
}
