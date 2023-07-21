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
            CreateMap<BienPatrimonial, BienPatrimonialReadDto > ()
                .ForMember(d => d.CategoriaString,
                    opt => opt.MapFrom(fuente => fuente.Categoria.Valor))
                .ForMember(d => d.ProcedimientoString,
                    opt => opt.MapFrom(fuente => fuente.Procedimiento.NombreReferencial));           
            CreateMap<BienPatrimonialCreateDto, BienPatrimonial>();           
            CreateMap<Procedimiento, ProcedimientoReadDto>()
                .ForMember(d => d.ProcedimientoTipoString, 
                    opt => opt.MapFrom(fuente => fuente.ProcedimientoTipo.Valor))
                .ForMember(d => d.CausalString,
                    opt => opt.MapFrom(fuente => fuente.Causal.Valor));
            CreateMap<ProcedimientoCreateDto, Procedimiento>();
            CreateMap<Area, AreaReadDto>()
                .ForMember(d => d.SedeString,
                    opt => opt.MapFrom(fuente => fuente.Sede.Valor))
                .ForMember(d => d.DependenciaString,
                    opt => opt.MapFrom(fuente => fuente.Dependencia.Valor))
                .ForMember(d => d.EstadoAreaString,
                    opt => opt.MapFrom(fuente => fuente.EstadoArea.Valor));                
            CreateMap<AreaCreateDto, Area>();
            CreateMap<Inventario, InventarioReadDto>();
            CreateMap<InventarioCreateDto, Inventario>();
            CreateMap<ProcedimientoBien, ProcedimientoBienReadDto>();
            CreateMap<ProcedimientoBienCreateDto, ProcedimientoBien>();
            //SUPERTEST
            CreateMap<BienProcedimientoAlta, Procedimiento>()         
               .ForMember(d => d.NombreReferencial,
                   opt => opt.MapFrom(fuente => fuente.NombreReferencial))
               .ForMember(d => d.NumeroGuia,
                   opt => opt.MapFrom(fuente => fuente.NumeroGuia))
              .ForMember(d => d.FechaDocumento,
                   opt => opt.MapFrom(fuente => fuente.FechaDocumento))
              .ForMember(d => d.FechaRegistro,
                   opt => opt.MapFrom(fuente => fuente.FechaRegistro))
              .ForMember(d => d.CausalId,
                   opt => opt.MapFrom(fuente => fuente.CausalId))
              .ForMember(d => d.ProcedimientoTipoId,
                   opt => opt.MapFrom(fuente => fuente.ProcedimientoTipoId));
            CreateMap<BienProcedimientoAlta, BienPatrimonial>()      
              .ForMember(d => d.Denominacion,
                  opt => opt.MapFrom(fuente => fuente.Denominacion))
              .ForMember(d => d.CodigoSBN,
                  opt => opt.MapFrom(fuente => fuente.CodigoSBN))
             .ForMember(d => d.Marca,
                  opt => opt.MapFrom(fuente => fuente.Marca))
             .ForMember(d => d.Modelo,
                  opt => opt.MapFrom(fuente => fuente.Modelo))
             .ForMember(d => d.Serie,
                  opt => opt.MapFrom(fuente => fuente.Serie))
             .ForMember(d => d.Color,
                  opt => opt.MapFrom(fuente => fuente.Color))
              .ForMember(d => d.Observacion,
                  opt => opt.MapFrom(fuente => fuente.Observacion))
               .ForMember(d => d.CategoriaId,
                  opt => opt.MapFrom(fuente => fuente.CategoriaId))
                //.ForMember(d => d.ProcedimientoId,
                //  opt => opt.MapFrom(fuente => fuente.ProcedimientoId))
                ;
        }
    }
}
