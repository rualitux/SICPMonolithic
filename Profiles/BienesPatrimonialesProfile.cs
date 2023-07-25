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
                //.ForMember(d => d.ProcedimientoString,
                //    opt => opt.MapFrom(fuente => fuente.Procedimiento.NombreReferencial))
                ;           
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
            CreateMap<Inventario, InventarioReadDto>()
                 .ForMember(d => d.BienPatrimonialString,
                    opt => opt.MapFrom(fuente => fuente.BienPatrimonial.Denominacion))
                .ForMember(d => d.AreaString,
                    opt => opt.MapFrom(fuente => fuente.Area.Nombre))
                .ForMember(d => d.AnexoTipoString,
                    opt => opt.MapFrom(fuente => fuente.AnexoTipo.Valor))
                .ForMember(d => d.EstadoBienString,
                    opt => opt.MapFrom(fuente => fuente.EstadoBien.Valor))
                .ForMember(d => d.EstadoCondicionString,
                    opt => opt.MapFrom(fuente => fuente.EstadoCondicion.Valor))
                 .ForMember(d => d.EstadoCondicionString,
                    opt => opt.MapFrom(fuente => fuente.EstadoCondicion.Valor))
                 .ForMember(d => d.ProcedimientoString,
                    opt => opt.MapFrom(fuente => fuente.Procedimiento.NombreReferencial))
                 ;
            CreateMap<InventarioCreateDto, Inventario>();
            CreateMap<ProcedimientoInventario, ProcedimientoBienReadDto>();
            CreateMap<ProcedimientoBienCreateDto, ProcedimientoInventario>();
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
            CreateMap<BienPatrimonial, BienProcedimientoAltaRetorno>()
                .ForMember(d => d.BienId,
                  opt => opt.MapFrom(fuente => fuente.Id))
                .ForMember(d => d.BienString,
                  opt => opt.MapFrom(fuente => fuente.Denominacion));
            
            CreateMap<Procedimiento, BienProcedimientoAltaRetorno>()
                 .ForMember(d => d.ProcedimientoId,
                  opt => opt.MapFrom(fuente => fuente.Id))
                 .ForMember(d => d.ProcedimientoString,
                  opt => opt.MapFrom(fuente => fuente.NombreReferencial));

            //Ajuste
            CreateMap<Ajuste, AjusteReadDto>()
                .ForMember(d => d.AjusteTipoString,
                 opt => opt.MapFrom(fuente => fuente.AjusteTipo.Valor));
            CreateMap<AjusteCreateDto, Ajuste>();
            CreateMap<AjusteDetalle, AjusteDetalleReadDto>()
                 .ForMember(d => d.AjusteString,
                 opt => opt.MapFrom(fuente => fuente.Ajuste.Justificacion))
                 .ForMember(d => d.AreaDestinoString,
                 opt => opt.MapFrom(fuente => fuente.AreaDestino.Nombre))
                 .ForMember(d => d.AreaOrigenString,
                 opt => opt.MapFrom(fuente => fuente.AreaOrigen.Nombre))
                 .ForMember(d => d.InventarioString,
                 opt => opt.MapFrom(fuente => fuente.Inventario.BienPatrimonial.Denominacion));
            CreateMap<AjusteDetalleCreateDto, AjusteDetalle>();
            CreateMap<Ajuste, AjustoExtendidoDto>()
               .ForMember(d => d.AjusteString,
                  opt => opt.MapFrom(fuente => fuente.Justificacion))
                .ForMember(d => d.AjusteTipoString,
                  opt => opt.MapFrom(fuente => fuente.AjusteTipo.Valor));
            CreateMap<AjusteDetalle, AjustoExtendidoDto>()
                .ForMember(d => d.AreaDestinoString,
                   opt => opt.MapFrom(fuente => fuente.AreaDestino.Nombre))
                  .ForMember(d => d.AreaOrigenString,
                   opt => opt.MapFrom(fuente => fuente.AreaOrigen.Nombre))
                  .ForMember(d => d.InventarioString,
                   opt => opt.MapFrom(fuente => fuente.Inventario.BienPatrimonial.Denominacion))
                  .ForMember(d => d.AjusteString,
                   opt => opt.MapFrom(fuente => fuente.Ajuste.Justificacion))
                   .ForMember(d => d.AjusteTipoId,
                   opt => opt.MapFrom(fuente => fuente.Ajuste.AjusteTipoId))
                  .ForMember(d => d.AjusteTipoString,
                   opt => opt.MapFrom(fuente => fuente.Ajuste.AjusteTipo.Valor))
                  
                  ;               



            CreateMap<AjusteMovimientoDto, Ajuste>()
               .ForMember(d => d.Justificacion,
                   opt => opt.MapFrom(fuente => fuente.Justificacion))
               .ForMember(d => d.FechaRegistro,
                   opt => opt.MapFrom(fuente => fuente.FechaRegistro))
               .ForMember(d => d.AjusteTipoId,
                   opt => opt.MapFrom(fuente => fuente.AjusteTipoId));
            CreateMap<AjusteMovimientoDto, AjusteDetalle>()
             .ForMember(d => d.CantidadAfectada,
                 opt => opt.MapFrom(fuente => fuente.CantidadAfectada))
             .ForMember(d => d.InventarioId,
                 opt => opt.MapFrom(fuente => fuente.InventarioId))
             .ForMember(d => d.AreaDestinoId,
                 opt => opt.MapFrom(fuente => fuente.AreaDestinoId))
               .ForMember(d => d.AreaOrigenId,
                 opt => opt.MapFrom(fuente => fuente.AreaOrigenId))
                 .ForMember(d => d.AjusteId,
                 opt => opt.MapFrom(fuente => fuente.AjusteId));

            //SUPERBAJA
            CreateMap<AjusteBajaDto, Ajuste>()
                   .ForMember(d => d.Justificacion,
                   opt => opt.MapFrom(fuente => fuente.Justificacion))
               .ForMember(d => d.FechaRegistro,
                   opt => opt.MapFrom(fuente => fuente.FechaRegistro))
               //.ForMember(d => d.AjusteTipoId,
               //    opt => opt.MapFrom(fuente => fuente.AjusteTipoId))
               ;
            CreateMap<AjusteBajaDto, AjusteDetalle>()
                  .ForMember(d => d.CantidadAfectada,
                  opt => opt.MapFrom(fuente => fuente.CantidadAfectada))
              .ForMember(d => d.AjusteId,
                  opt => opt.MapFrom(fuente => fuente.FechaRegistro))
              .ForMember(d => d.AjusteId,
                  opt => opt.MapFrom(fuente => fuente.AjusteId))
              //.ForMember(d => d.AreaDestinoId,
              //    opt => opt.MapFrom(fuente => fuente.AreaDestinoId))
              //.ForMember(d => d.AreaOrigenId,
              //    opt => opt.MapFrom(fuente => fuente.AreaOrigenId))
              ;
            CreateMap<AjusteBajaDto, Procedimiento>()
                 .ForMember(d => d.NombreReferencial,
                 opt => opt.MapFrom(fuente => fuente.NombreReferencial))
             .ForMember(d => d.NumeroDocumento,
                 opt => opt.MapFrom(fuente => fuente.NumeroDocumento))
             .ForMember(d => d.NumeroGuia,
                 opt => opt.MapFrom(fuente => fuente.NumeroGuia))
             //.ForMember(d => d.ProcedimientoTipoId,
             //    opt => opt.MapFrom(fuente => fuente.ProcedimientoTipoId))
             .ForMember(d => d.CausalId,
                 opt => opt.MapFrom(fuente => fuente.CausalId))
             .ForMember(d => d.FechaDocumento,
                 opt => opt.MapFrom(fuente => fuente.FechaDocumento))
             .ForMember(d => d.FechaRegistro,
                 opt => opt.MapFrom(fuente => fuente.FechaRegistro));
            CreateMap<AjusteBajaDto, Inventario>()
               .ForMember(d => d.Cantidad,
               opt => opt.MapFrom(fuente => fuente.CantidadAfectada))
               .ForMember(d => d.FechaRegistro,
               opt => opt.MapFrom(fuente => fuente.FechaRegistro))
               .ForMember(d => d.BienPatrimonialId,
               opt => opt.MapFrom(fuente => fuente.BienPatrimonialId))
               .ForMember(d => d.AnexoTipoId,
               opt => opt.MapFrom(fuente => fuente.AnexoTipoId))
               .ForMember(d => d.EstadoCondicionId,
               opt => opt.MapFrom(fuente => fuente.EstadoCondicionId))
               //.ForMember(d => d.EstadoBienId,
               //opt => opt.MapFrom(fuente => fuente.EstadoBienId))
               .ForMember(d => d.AreaId,
               opt => opt.MapFrom(fuente => fuente.AreaId))
               //.ForMember(d => d.ProcedimientoId,
               //opt => opt.MapFrom(fuente => fuente.ProcedimientoId))
               ;

        }
    }
}
