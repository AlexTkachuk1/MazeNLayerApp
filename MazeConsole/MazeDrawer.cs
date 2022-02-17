using NLayerApp.BLL_.DTO.Cells;
using NLayerApp.BLL_.DTO.Interfaces;

namespace MazeConsole
{
    public class MazeDrawer
    {
        public void Draw(IMaze maze)
        {
            foreach (var cell in maze.CellsWithHero)
            {
                Console.SetCursorPosition(cell.CordinateX, cell.CordinateY);
                if (cell is Wall)
                {
                    //Console.BackgroundColor = ConsoleColor.White;
                    //Console.Write("U+2B1C",UTF32Encoding.Equals(U+2B1C));
                    //Console.OutputEncoding = System.Text.Encoding.UTF8;
                    Console.WriteLine("#");
                    //Console.BackgroundColor = ConsoleColor.Black;
                }
                if (cell is Ground)
                {
                    Console.Write(".");
                }
                if (cell is GoldHeap)
                {
                    Console.Write("$");
                }
                if (cell is Сhest)
                {
                    Console.Write("?");
                }
                if (cell is CellWithHero)
                {
                    Console.Write("@");
                }
                if (cell is Trap)
                {
                    Console.Write("*");
                }
                if (cell is Gate)
                {
                    Console.Write("O");
                }
                if (cell is Lava)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }

            Console.SetCursorPosition(0, maze.Height + 1);
        }
    }
}

