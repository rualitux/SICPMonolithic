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
    public class AreasController : ControllerBase
    {
        private readonly IAreaRepository _repository;
        private readonly IMapper _mapper;

        public AreasController(IAreaRepository repository, IMapper mapper)           
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<AreaReadDto>> GetAreas()
        {
            Console.WriteLine("Sacando areas");
            var items = _repository.GetAllAreas();
            return Ok(_mapper.Map<IEnumerable<AreaReadDto>>(items));
        }


        [HttpGet("{id}", Name = "GetAreaById")]
        public ActionResult<AreaReadDto> GetAreaById(int id)
        {
            var item = _repository.GetAreaById(id);
            if (item != null)
            {
                return Ok(_mapper.Map<AreaReadDto>(item));
            }
            return NotFound();

        }        

        [HttpPost(Name = "CreateArea")]
        public async Task<IActionResult> CreateArea(AreaCreateDto areaCreateDto)
        {
            Console.WriteLine($"Creando area");
            var item = _mapper.Map<Area>(areaCreateDto);
            _repository.CreateArea(item);
            _repository.Save();
            Console.WriteLine("Hasta aquí guardó area");
            var itemReadDto = _mapper.Map<AreaReadDto>(item);
            return CreatedAtAction("CreateArea", itemReadDto);      
        }
        [HttpPut("{areaId}", Name = "UpdateArea")]
        public async Task<IActionResult> UpdateArea(int areaId, AreaCreateDto areaCreateDto)
        {
            if (areaId != areaCreateDto.Id)
            {
                return BadRequest(ModelState);
            }
            Console.WriteLine($"Updateando area");
            var item = _mapper.Map<Area>(areaCreateDto);
            _repository.UpdateArea(item);
            _repository.Save();
            Console.WriteLine("Hasta aquí guardó area");
            var itemReadDto = _mapper.Map<AreaReadDto>(item);
            return CreatedAtAction("CreateArea", itemReadDto);
        }

    }
}
