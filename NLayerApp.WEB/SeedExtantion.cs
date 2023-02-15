using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.BLL_.Interfaces;

namespace NLayerApp.WEB
{
    public static class SeedExtantion
    {
        public static IHost Seed(this IHost host)
        {
            using (var service = host.Services.CreateScope())
            {
                InitHero(service.ServiceProvider);
            }

            return host;
        }

        private static void InitHero(IServiceProvider service)
        {
            var mazeService = service.GetService<IMazeService>();
            IMaze maze = mazeService.BuildMaze();
            maze.Name = "initMaze";
            mazeService.SaveMaze(maze);
        }
    }
}
