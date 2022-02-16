using AutoMapper;
using NLayerApp.BLL_.DTO.Items;
using NLayerApp.WEB.Models;

namespace NLayerApp.WEB.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<BaseItem, ItemViewModel> ()
                .ForMember(
                    dest => dest.Name,
                    from => from.MapFrom(x => $"{x.Name}")
                );
        }
    }
}
