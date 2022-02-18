﻿using NLayerApp.BLL_.DTO.Interfaces;

namespace NLayerApp.BLL_.DTO.Cells
{
    public class Boss:BaseCell
    {
        public Boss(int x, int y, IMaze maze) : base(x, y, maze)
        {
        }

        public override bool TryStep()
        {
            return false;
        }
    }
}