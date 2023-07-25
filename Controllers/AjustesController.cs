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
    public class AjustesController : ControllerBase
    {
        private readonly IBienPatrimonialRepository _repository;
        private readonly IMapper _mapper;

        public AjustesController(IBienPatrimonialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AjusteReadDto>> GerAjustes()
        {
            Console.WriteLine("Sacando ajustes");
            var items = _repository.GetAllAjustes();
            return Ok(_mapper.Map<IEnumerable<AjusteReadDto>>(items));
        }

        [HttpGet("extendido")]
        public ActionResult<IEnumerable<AjustoExtendidoDto>> GerAjustesExtendido()
        {
            Console.WriteLine("Sacando ajustes");
            var items = _repository.GetAllAjusteDetalles();
            return Ok(_mapper.Map<IEnumerable<AjustoExtendidoDto>>(items));
        }


        [HttpGet("detalles")]
        public ActionResult<IEnumerable<AjusteDetalleReadDto>> GetAjusteDetalles()
        {
            Console.WriteLine("Sacando detalles de ajuste");
            var items = _repository.GetAllAjusteDetalles();
            return Ok(_mapper.Map<IEnumerable<AjusteDetalleReadDto>>(items));
        }



        [HttpGet("{id}", Name = "GetAjusteById")]
        public ActionResult<AjusteReadDto> GetAjusteById(int id)
        {
            var item = _repository.GetAjusteById(id);
            if (item != null)
            {
                return Ok(_mapper.Map<AjusteReadDto>(item));
            }
            return NotFound();
        }

        [HttpPost(Name = "CreateAjuste")]
        public async Task<IActionResult> CreateAjuste(AjusteCreateDto ajusteCreateDto)
        {
            Console.WriteLine($"Creando ajuste");
            var item = _mapper.Map<Ajuste>(ajusteCreateDto);
            _repository.CreateAjuste(item);
            _repository.Save();
            Console.WriteLine("Hasta aquí guardó inventario");
            var itemPosteado = _repository.GetAjusteById(item.Id);
            var itemReadDto = _mapper.Map<AjusteReadDto>(itemPosteado);
            return CreatedAtAction("CreateAjuste", itemReadDto);
        }
        [HttpPost("detalles", Name = "CreateAjusteDetalle")]
        public async Task<IActionResult> CreateAjusteDetalle(AjusteDetalleCreateDto ajusteDetalleCreateDto)
        {
            Console.WriteLine($"Creando ajuste");
            var item = _mapper.Map<AjusteDetalle>(ajusteDetalleCreateDto);
            _repository.CreateAjusteDetalle(item);
            _repository.Save();
            Console.WriteLine("Hasta aquí guardó inventario");
            var itemPosteado = _repository.GetAjusteDetalleById(item.Id);
            var itemReadDto = _mapper.Map<AjusteDetalleReadDto>(itemPosteado);
            return CreatedAtAction("CreateAjusteDetalle", itemReadDto);
        }


        [HttpPost("alta", Name = "MoverInventario")]
        public async Task<IActionResult> MoverInventario(AjusteMovimientoDto ajusteMovimientoDto)
        {
            using var transactionTest = _repository.CrearTransaccion();
            {
                //var ajuste = _mapper.Map<Ajuste>(ajusteMovimientoDto);
                //_repository.CreateAjuste(ajuste);
                //_repository.Save();
                //var ajusteDetalle = _mapper.Map<AjusteDetalle>(ajusteMovimientoDto);
                ////No sé cómo mapear esto :/
                //_repository.CreateAjusteDetalle(ajusteDetalle);
                //_repository.Save();
                //transactionTest.Commit();
                //var retorno = _mapper.Map(bien, _mapper.Map<Procedimiento, BienProcedimientoAltaRetorno>(procedimiento));
                //return CreatedAtAction("AltaBienProcedimiento", retorno);
                return null;
            }
        }


    }
}
