using NLayerApp.BLL_.BusinessModels;
using NLayerApp.BLL_.DTO;

namespace MazeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildMaze();
        }

        public static void BuildMaze()
        {
            var builder = new MazeBuilderTest();

            var drawer = new MazeDrawer();
        
            var maze = builder.Build(5, 5, drawer.Draw);

            drawer.Draw(maze);

            var exit = false;
            while (!exit)
            {
                var gateCell = maze.Cells.Single(x => x.GetType().Name == "Gate");
                if (maze.Hero.X == gateCell.CordinateX && maze.Hero.Y == gateCell.CordinateY)
                {
                    var newMaze = builder.Build(maze.Width, maze.Height, drawer.Draw);
                    newMaze.Hero.Gold = maze.Hero.Gold;
                    newMaze.Hero.Inventory = maze.Hero.Inventory;
                    maze = newMaze;
                }
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        maze.TryToStep(Direction.Up);
                        break;
                    case ConsoleKey.RightArrow:
                        maze.TryToStep(Direction.Right);
                        break;
                    case ConsoleKey.DownArrow:
                        maze.TryToStep(Direction.Down);
                        break;
                    case ConsoleKey.LeftArrow:
                        maze.TryToStep(Direction.Left);
                        break;
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                }
                builder.StateOfTheMaze(maze);
                drawer.Draw(maze);
            }
        }
    }
}