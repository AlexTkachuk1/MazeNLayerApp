using AutoMapper;
using NLayerApp.BLL_.DTO.Cells;
using NLayerApp.DAL_.Entities;
using NLayerApp.WEB.Models;

namespace NLayerApp.WEB.Profiles
{
    public class CellProfile : Profile
    {
        public CellProfile()
        {
            CreateMap<CellWithHero, CellViewModel>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );

            CreateMap<Gate, CellViewModel>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );

            CreateMap<GoldHeap, CellViewModel>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );

            CreateMap<Ground, CellViewModel>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );

            CreateMap<Lava, CellViewModel>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );

            CreateMap<Wall, CellViewModel>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );

            CreateMap<Trap, CellViewModel>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );

            CreateMap<Сhest, CellViewModel>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );
            CreateMap<Trap, CellViewModel>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );

            CreateMap<CellWithHero, Cell>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );

            CreateMap<Gate, Cell>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );

            CreateMap<GoldHeap, Cell>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );

            CreateMap<Ground, Cell>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );

            CreateMap<Lava, Cell>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );

            CreateMap<Wall, Cell>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );

            CreateMap<Trap, Cell>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );

            CreateMap<Сhest, Cell>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );
            CreateMap<Trap, Cell>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );

            CreateMap<Cell, CellViewModel>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.TypeName}")
                );

            CreateMap<CellViewModel, Cell>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.TypeName}")
                );
            CreateMap<Legionary, Cell>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );
            CreateMap<Legionary, CellViewModel>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );
            CreateMap<Boss, Cell>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );
            CreateMap<Boss, CellViewModel>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );
            CreateMap<Teleport, Cell>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );
            CreateMap<Teleport, CellViewModel>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.TypeName,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );
        }
    }
}
