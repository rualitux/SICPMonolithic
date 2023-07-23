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

        [HttpPost(Name = "CreateInventario")]
        public async Task<IActionResult> CreateInventario(InventarioCreateDto inventarioCreateDto)
        {
            Console.WriteLine($"Creando inventario");
            var item = _mapper.Map<Inventario>(inventarioCreateDto);
            _repository.CreateInventario(item);
            _repository.Save();   
            Console.WriteLine("Hasta aquí guardó inventario"); 
            var inventarioPosteado = _repository.GetInventarioById(item.Id);
            var itemReadDto = _mapper.Map<InventarioReadDto>(inventarioPosteado);
            return CreatedAtAction("CreateInventario", itemReadDto);           
        }


    }
}
