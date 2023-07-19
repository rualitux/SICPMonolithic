using AutoMapper;
using SICPMonolithic.Dtos;
using SICPMonolithic.Models;

namespace SICPMonolithic.Profiles
{
    public class BienesPatrimonialesProfile : Profile
    {
        public BienesPatrimonialesProfile()
        {
            CreateMap<Enumerado, EnumeradoReadDto>();
            CreateMap<BienPatrimonial, BienPatrimonialReadDto > ();
            CreateMap<BienPatrimonialCreateDto, BienPatrimonial>();           
            CreateMap<Procedimiento, ProcedimientoReadDto>()
           .ForMember(d => d.ProcedimientoTipoString, 
           opt => opt.MapFrom(fuente => fuente.ProcedimientoTipo.Valor))
           .ForMember(d => d.CausalString,
           opt => opt.MapFrom(fuente => fuente.Causal.Valor))
           ;
            CreateMap<ProcedimientoCreateDto, Procedimiento>();
            CreateMap<Area, AreaReadDto>();
            CreateMap<AreaCreateDto, Area>();
            CreateMap<Inventario, InventarioReadDto>();
            CreateMap<InventarioCreateDto, Inventario>();
            CreateMap<ProcedimientoBien, ProcedimientoBienReadDto>();
            CreateMap<ProcedimientoBienCreateDto, ProcedimientoBien>();           
        }
    }
}
