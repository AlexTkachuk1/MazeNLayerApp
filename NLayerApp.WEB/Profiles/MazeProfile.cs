using AutoMapper;
using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.DAL_.Entities;
using NLayerApp.WEB.Models;

namespace NLayerApp.WEB.Profiles
{
    public class MazeProfile : Profile
    {
        public MazeProfile()
        {
            CreateMap<IMaze, ReadyMazeViewModel > ()
                .ForMember(
                    dest => dest.MazeWidth,
                    from => from.MapFrom(x => $"{x.Width}")
                )
                .ForMember(
                    dest => dest.MazeHeight,
                    from => from.MapFrom(x => $"{x.Height}")
                );

            CreateMap<IMaze, Maze>()
                .ForMember(
                    dest => dest.Width,
                    from => from.MapFrom(x => $"{x.Width}")
                )
                .ForMember(
                    dest => dest.Height,
                    from => from.MapFrom(x => $"{x.Height}")
                );

            CreateMap<IMaze, Maze>()
                .ForMember(
                    dest => dest.Width,
                    from => from.MapFrom(x => $"{x.Width}")
                )
                .ForMember(
                    dest => dest.Height,
                    from => from.MapFrom(x => $"{x.Height}")
                );

            CreateMap<Maze, ReadyMazeViewModel>()
                .ForMember(
                    dest => dest.MazeWidth,
                    from => from.MapFrom(x => $"{x.Width}")
                )
                .ForMember(
                    dest => dest.MazeHeight,
                    from => from.MapFrom(x => $"{x.Height}")
                );

            CreateMap<ReadyMazeViewModel, Maze>()
                .ForMember(
                    dest => dest.Width,
                    from => from.MapFrom(x => $"{x.MazeWidth}")
                )
                .ForMember(
                    dest => dest.Height,
                    from => from.MapFrom(x => $"{x.MazeHeight}")
                );
        }
    }
}
