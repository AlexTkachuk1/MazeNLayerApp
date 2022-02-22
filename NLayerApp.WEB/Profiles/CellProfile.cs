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
            CreateMap<MiracleShop, Cell>()
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
            CreateMap<MiracleShop, CellViewModel>()
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
            CreateMap<Killer, Cell>()
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
            CreateMap<Killer, CellViewModel>()
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
            CreateMap<InvisibleTrap, Cell>()
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
            CreateMap<InvisibleTrap, CellViewModel>()
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
            
            
            
            
            
            
            
            CreateMap<Assassin, Cell>()
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
            CreateMap<Assassin, CellViewModel>()
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
            CreateMap<AverageTreatmentPotion, Cell>()
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
            CreateMap<AverageTreatmentPotion, CellViewModel>()
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
            CreateMap<BagOfGold, Cell>()
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
            CreateMap<BagOfGold, CellViewModel>()
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
            CreateMap<Champion, Cell>()
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
            CreateMap<Champion, CellViewModel>()
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
            CreateMap<DamnEarth, Cell>()
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
            CreateMap<DamnEarth, CellViewModel>()
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
            CreateMap<DeadMan, Cell>()
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
            CreateMap<DeadMan, CellViewModel>()
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
            CreateMap<DecomposedCorpse, Cell>()
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
            CreateMap<DecomposedCorpse, CellViewModel>()
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
            CreateMap<Draconian, Cell>()
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
            CreateMap<Draconian, CellViewModel>()
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
            CreateMap<Dragon, Cell>()
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
            CreateMap<Dragon, CellViewModel>()
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
            CreateMap<Elf, Cell>()
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
            CreateMap<Elf, CellViewModel>()
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
            CreateMap<ExperiencedWarrior, Cell>()
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
            CreateMap<ExperiencedWarrior, CellViewModel>()
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
            CreateMap<Goblin, Cell>()
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
            CreateMap<Goblin, CellViewModel>()
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
            CreateMap<Mutant, Cell>()
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
            CreateMap<Mutant, CellViewModel>()
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
            CreateMap<Robot, Cell>()
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
            CreateMap<Robot, CellViewModel>()
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
            CreateMap<SmallPotionTreatment, Cell>()
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
            CreateMap<SmallPotionTreatment, CellViewModel>()
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
            CreateMap<SwampCreature, Cell>()
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
            CreateMap<SwampCreature, CellViewModel>()
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
