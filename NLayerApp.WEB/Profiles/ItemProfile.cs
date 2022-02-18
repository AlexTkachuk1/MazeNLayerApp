using AutoMapper;
using NLayerApp.BLL_.DTO.Items;
using NLayerApp.DAL_.Entities;
using NLayerApp.WEB.Models;

namespace NLayerApp.WEB.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Shield, ItemViewModel> ()
                .ForMember(
                    dest => dest.Name,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );

            CreateMap<Shield, Item>()
               .ForMember(
                   dest => dest.Name,
                   from => from.MapFrom(x => $"{x.GetType().Name}")
               );
            CreateMap<Sword, ItemViewModel>()
                .ForMember(
                    dest => dest.Name,
                    from => from.MapFrom(x => $"{x.GetType().Name}")
                );

            CreateMap<Sword, Item>()
               .ForMember(
                   dest => dest.Name,
                   from => from.MapFrom(x => $"{x.GetType().Name}")
               );

            CreateMap<Item, ItemViewModel>()
                .ForMember(
                    dest => dest.Name,
                    from => from.MapFrom(x => $"{x.Name}")
                );

            CreateMap<ItemViewModel, Item>()
               .ForMember(
                   dest => dest.Name,
                   from => from.MapFrom(x => $"{x.Name}")
               );
        }
    }
}
