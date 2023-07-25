using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SICPMonolithic.Dtos;
using SICPMonolithic.Interfaces;
using SICPMonolithic.Models;

namespace SICPMonolithic.Controllers
{
    [Route("api/i/[controller]")]
    [ApiController]
    public class InventariosController : ControllerBase
    {
        private readonly IBienPatrimonialRepository _repository;
        private readonly IMapper _mapper;

        public InventariosController(IBienPatrimonialRepository repository, IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;            
        }

        [HttpGet]
        public ActionResult<IEnumerable<InventarioReadDto>> GetInventarios()
        {
            Console.WriteLine("Sacando inventarios");
            var items = _repository.GetAllInventarios();
            return Ok(_mapper.Map<IEnumerable<InventarioReadDto>>(items));
        }

        [HttpGet("{id}", Name = "GetInventarioById")]
        public ActionResult<InventarioReadDto> GetInventarioById(int id)
        {
            var item = _repository.GetInventarioById(id);
            if (item != null)
            {
                return Ok(_mapper.Map<InventarioReadDto>(item));
            }
            return NotFound();
        }


        [HttpPost(Name = "CreateInventario")]
        public async Task<IActionResult> CreateInventario(InventarioCreateDto inventarioCreateDto)
        {
            using var transactionTest = _repository.CrearTransaccion();
            {
                Console.WriteLine($"Creando inventario");
                var item = _mapper.Map<Inventario>(inventarioCreateDto);
                _repository.CreateInventario(item);
                _repository.Save();
                var inventarioPosteado = _repository.GetInventarioById(item.Id);
                var ajuste = _repository.AjusteNuevoInventario(inventarioPosteado);
                _repository.CreateAjuste(ajuste);
                _repository.Save();
                var ajusteDetalle = _repository.AjusteDetalleNuevoInventario(ajuste, inventarioPosteado);
                _repository.CreateAjusteDetalle(ajusteDetalle);
                _repository.Save();
                Console.WriteLine("Hasta aquí guardó inventario");
                var itemReadDto = _mapper.Map<InventarioReadDto>(inventarioPosteado);
                return CreatedAtAction("CreateInventario", itemReadDto);
            }
        }

        [HttpPut("{inventarioId}", Name = "UpdateInventario")]
        public async Task<IActionResult> UpdateInventario(int inventarioId, InventarioCreateDto inventarioCreateDto)
        {
            if (inventarioId != inventarioCreateDto.Id)
            {
                return BadRequest(ModelState);
            }           
            Console.WriteLine($"Updateando bien");
            var item = _mapper.Map<Inventario>(inventarioCreateDto);
            _repository.UpdateInventario(item);
            _repository.Save();
            Console.WriteLine("Hasta aquí guardó bien");
            var itemReadDto = _mapper.Map<InventarioReadDto>(item);
            return CreatedAtAction("CreateInventario", itemReadDto);
        }

        [HttpPost("baja", Name = "BajaAjusteInventario")]
        public async Task<IActionResult> BajaAjusteInventario(AjusteBajaDto ajusteBajaDto)
        {
            using var transactionTest = _repository.CrearTransaccion();
            {
                var procedimiento = _mapper.Map<Procedimiento>(ajusteBajaDto);
                procedimiento.ProcedimientoTipoId = 27;
                _repository.CreateProcedimiento(procedimiento);
                _repository.Save();  
                //Obtengo el inventario original
                var inventarioOriginal = _repository.GetInventarioById((int)ajusteBajaDto.InventarioId);
                //Actualizo cantidad en inventario original
                inventarioOriginal.Cantidad -= ajusteBajaDto.CantidadAfectada;
                if (inventarioOriginal.Cantidad <= 0)
                {
                    inventarioOriginal.EstadoBienId = 30;
                }

                _repository.UpdateInventario(inventarioOriginal);
                _repository.Save();
                //Creo nuevo ajuste
                var ajuste = _mapper.Map<Ajuste>(ajusteBajaDto);
                ajuste.AjusteTipoId = 28;
                _repository.CreateAjuste(ajuste);
                //Creo nuevo ajuste detalle
                var ajusteDetalle = _mapper.Map<AjusteDetalle>(ajusteBajaDto);
                ajusteDetalle.AjusteId = ajuste.Id;
                _repository.CreateAjusteDetalle(ajusteDetalle);
                _repository.Save();
                //Creo un inventario nuevo con la diferencia de cantidades
                //creo no es necesario por el mapping...
                var inventario = _mapper.Map<Inventario>(ajusteBajaDto);
                inventario.ProcedimientoId = procedimiento.Id;
                inventario.EstadoBienId = 30;
                _repository.CreateInventario(inventario);
                _repository.Save();
                transactionTest.Commit();
                return CreatedAtAction("BajaAjusteInventario", inventario);
            }
        }


    }
}
