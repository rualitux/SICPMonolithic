using AutoMapper;
using SICPMonolithic.Dtos;
using SICPMonolithic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SICPMonolithic.Models;

namespace SICPMonolithic.Controllers
{
    [ApiController]
    //[Route("api/i/enumerados/{enumeradoId}/[controller]")]
    [Route("api/i/[controller]")]
    public class ProcedimientosController: ControllerBase
    {
        private readonly IProcedimientoRepository _repository;
        private readonly IMapper _mapper;

        public ProcedimientosController(IProcedimientoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProcedimientoReadDto>> GetProcedimientos()
        {
            Console.WriteLine("Sacando procedimientos");
            var procedimientoItem = _repository.GetAllProcedimientos();
            return Ok(_mapper.Map<IEnumerable<ProcedimientoReadDto>>(procedimientoItem));
        }


        [HttpGet("{id}", Name = "GetProcedimientoById")]
        public ActionResult<ProcedimientoReadDto> GetProcedimientoById(int id)
        {
            var procedimientoItem = _repository.GetProcedimientoById(id);
            if (procedimientoItem != null)
            {
                return Ok(_mapper.Map<ProcedimientoReadDto>(procedimientoItem));
            }
            return NotFound();

        }

        [HttpGet("/a/{id}", Name = "GetAltas")]
        public ActionResult<ProcedimientoReadDto> GetAltas(int id)
        {
            var procedimientoItem = _repository.GetAltas(id);
            if (procedimientoItem != null)
            {
                return Ok(_mapper.Map<ProcedimientoReadDto>(procedimientoItem));
            }
            return NotFound();

        }


        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create(ProcedimientoCreateDto procedimientoCreateDto)
        {
            Console.WriteLine($"Creando procedimiento");
            var procedimiento = _mapper.Map<Procedimiento>(procedimientoCreateDto);
            _repository.CreateProcedimiento(procedimiento);
            _repository.Save();
            Console.WriteLine("Hasta aquí guardó procedimiento");
            var procedimientoReadDto = _mapper.Map<ProcedimientoReadDto>(procedimiento);
            return CreatedAtAction("Create", procedimientoReadDto);
            //if (ModelState.IsValid)
            //{
            //    piscicultor.Estado = 0;
            //    piscicultor.FechaRegistro = DateTime.Now;
            //    piscicultor.FechaModificacion = DateTime.Now;
            //    _context.Add(piscicultor);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(piscicultor);
        }
        [HttpPut("{procedimientoId}", Name = "Update")]
        public async Task<IActionResult> Update(int procedimientoId, ProcedimientoCreateDto procedimientoCreateDto)
        {
            if (procedimientoId != procedimientoCreateDto.Id)
            {
                return BadRequest(ModelState);
            }
            Console.WriteLine($"Updateando procedimiento");
            var procedimiento = _mapper.Map<Procedimiento>(procedimientoCreateDto);
            _repository.UpdateProcedimiento(procedimiento);
            _repository.Save();
            Console.WriteLine("Hasta aquí guardó procedimiento");
            var procedimientoReadDto = _mapper.Map<ProcedimientoReadDto>(procedimiento);
            return CreatedAtAction("Create", procedimientoReadDto);
        }

        }
}
