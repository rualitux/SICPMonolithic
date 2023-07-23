using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SICPMonolithic.Dtos;
using SICPMonolithic.Interfaces;
using SICPMonolithic.Models;

namespace SICPMonolithic.Controllers
{
    [Route("api/i/[controller]")]
    [ApiController]
    public class BienesController : ControllerBase
    {
        private readonly IBienPatrimonialRepository _repository;
        private readonly IMapper _mapper;

        public BienesController(IBienPatrimonialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BienPatrimonialReadDto>> GetBienes()
        {
            Console.WriteLine("Sacando bienes");
            var items = _repository.GetAllBienes();
            return Ok(_mapper.Map<IEnumerable<BienPatrimonialReadDto>>(items));
        }

        [HttpGet("{id}", Name = "GetBienById")]
        public ActionResult<BienPatrimonialReadDto> GetBienById(int id)
        {
            var item = _repository.GetBienById(id);
            if (item != null)
            {
                return Ok(_mapper.Map<BienPatrimonialReadDto>(item));
            }
            return NotFound();
        }

        [HttpPost(Name = "CreateBien")]
        public async Task<IActionResult> CreateBien(BienPatrimonialCreateDto bienPatrimonialCreateDto)
        {
            Console.WriteLine($"Creando bien");
            var item = _mapper.Map<BienPatrimonial>(bienPatrimonialCreateDto);
            _repository.CreateBien(item);
            _repository.Save();
            Console.WriteLine("Hasta aquí guardó bien");
            var itemReadDto = _mapper.Map<BienPatrimonialReadDto>(item);
            return CreatedAtAction("CreateBien", itemReadDto);
        }

        [HttpPost("alta", Name = "AltaBienProcedimiento")]
        public async Task<IActionResult> AltaBienProcedimiento(BienProcedimientoAlta bienProcedimientoAlta)
        {
            using var transactionTest = _repository.CrearTransaccion();
            {
                var procedimiento = _mapper.Map<Procedimiento>(bienProcedimientoAlta);
                _repository.CreateProcedimiento(procedimiento);
                _repository.Save();
                var bien = _mapper.Map<BienPatrimonial>(bienProcedimientoAlta);
                //No sé cómo mapear esto :/
                _repository.CreateBien(bien);
                _repository.Save();
                transactionTest.Commit();
                var retorno = _mapper.Map(bien, _mapper.Map<Procedimiento, BienProcedimientoAltaRetorno>(procedimiento));
                return CreatedAtAction("AltaBienProcedimiento", retorno);
            }
        }

  




        [HttpPut("{bienId}", Name = "UpdateBien")]
        public async Task<IActionResult> UpdateBien(int bienId, BienPatrimonialCreateDto bienPatrimonialCreateDto)
        {
            if (bienId != bienPatrimonialCreateDto.Id)
            {
                return BadRequest(ModelState);
            }
            Console.WriteLine($"Updateando bien");
            var item = _mapper.Map<BienPatrimonial>(bienPatrimonialCreateDto);
            _repository.UpdateBien(item);
            _repository.Save();
            Console.WriteLine("Hasta aquí guardó bien");
            var itemReadDto = _mapper.Map<BienPatrimonialReadDto>(item);
            return CreatedAtAction("CreateBien", itemReadDto);
        }





    }
}
