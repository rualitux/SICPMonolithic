using AutoMapper;
using SICPMonolithic.Dtos;
using SICPMonolithic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SICPMonolithic.Controllers
{
    [Route("api/i/[controller]")]
    [ApiController]
    public class EnumeradosController: ControllerBase
    {
        private readonly IEnumeradoRepository _repository;
        private readonly IMapper _mapper;

        public EnumeradosController(IEnumeradoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<EnumeradoReadDto>> GetEnumerados()
        {
            Console.WriteLine("Sacando Enumerados/Categorías de InventarioService");
            var enumeradoItems = _repository.GetAllEnumerados();
            return Ok(_mapper.Map<IEnumerable<EnumeradoReadDto>>(enumeradoItems));
        }
        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("POST entrante de Enumerados");
            return Ok("entrante test");
        }
    }
}
