using AutoMapper;
using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.WEB.Models;

namespace NLayerApp.WEB.Profiles
{
    public class MazeProfile : Profile
    {
        public MazeProfile()
        {
            CreateMap<IMaze, MazeDataForJsViewModel > ()
                .ForMember(
                    dest => dest.MazeWidth,
                    from => from.MapFrom(x => $"{x.Width}")
                )
                .ForMember(
                    dest => dest.MazeHeight,
                    from => from.MapFrom(x => $"{x.Height}")
                );
        }
    }
}
