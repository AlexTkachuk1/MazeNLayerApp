using AutoMapper;
using NLayerApp.BLL_.DTO.Interfaces;
using NLayerApp.DAL_.Entities;
using NLayerApp.WEB.Models;

namespace NLayerApp.WEB.Profiles
{
    public class HeroProfile : Profile
    {
        public HeroProfile()
        {
            CreateMap<IHero, HeroViewModel>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.X}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.Y}")
                )
                .ForMember(
                    dest => dest.Damage,
                    from => from.MapFrom(x => $"{x.Damage}")
                )
                .ForMember(
                    dest => dest.Gold,
                    from => from.MapFrom(x => $"{x.Gold}")
                )
                .ForMember(
                    dest => dest.HP,
                    from => from.MapFrom(x => $"{x.HP}")
                )
                .ForMember(
                    dest => dest.Stamina,
                    from => from.MapFrom(x => $"{x.Stamina}")
                );

            CreateMap<IHero, Hero>()
                .ForMember(
                    dest => dest.X,
                    from => from.MapFrom(x => $"{x.X}")
                )
                .ForMember(
                    dest => dest.Y,
                    from => from.MapFrom(x => $"{x.Y}")
                )
                .ForMember(
                    dest => dest.Damage,
                    from => from.MapFrom(x => $"{x.Damage}")
                )
                .ForMember(
                    dest => dest.Gold,
                    from => from.MapFrom(x => $"{x.Gold}")
                )
                .ForMember(
                    dest => dest.HP,
                    from => from.MapFrom(x => $"{x.HP}")
                )
                .ForMember(
                    dest => dest.Stamina,
                    from => from.MapFrom(x => $"{x.Stamina}")
                );

            CreateMap<HeroViewModel, Hero>()
                .ForMember(
                    dest => dest.X,
                    from => from.MapFrom(x => $"{x.CordinateX}")
                )
                .ForMember(
                    dest => dest.Y,
                    from => from.MapFrom(x => $"{x.CordinateY}")
                )
                .ForMember(
                    dest => dest.Damage,
                    from => from.MapFrom(x => $"{x.Damage}")
                )
                .ForMember(
                    dest => dest.Gold,
                    from => from.MapFrom(x => $"{x.Gold}")
                )
                .ForMember(
                    dest => dest.HP,
                    from => from.MapFrom(x => $"{x.HP}")
                )
                .ForMember(
                    dest => dest.Stamina,
                    from => from.MapFrom(x => $"{x.Stamina}")
                );

            CreateMap<Hero, HeroViewModel>()
                .ForMember(
                    dest => dest.CordinateX,
                    from => from.MapFrom(x => $"{x.X}")
                )
                .ForMember(
                    dest => dest.CordinateY,
                    from => from.MapFrom(x => $"{x.Y}")
                )
                .ForMember(
                    dest => dest.Damage,
                    from => from.MapFrom(x => $"{x.Damage}")
                )
                .ForMember(
                    dest => dest.Gold,
                    from => from.MapFrom(x => $"{x.Gold}")
                )
                .ForMember(
                    dest => dest.HP,
                    from => from.MapFrom(x => $"{x.HP}")
                )
                .ForMember(
                    dest => dest.Stamina,
                    from => from.MapFrom(x => $"{x.Stamina}")
                );
        }
    }
}
