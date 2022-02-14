using NLayerApp.BLL_.DTO.Interfaces;

namespace NLayerApp.BLL_.DTO.Cells
{
    public class CellWithHero : BaseCell
    {
        public CellWithHero(IHero hero, IMaze maze) : base(hero.X, hero.Y, maze)
        {
        }

        public override bool TryStep()
        {
            throw new NotImplementedException();
        }
    }
}