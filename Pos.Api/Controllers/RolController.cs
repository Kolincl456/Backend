using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pos.Dto.Dto;
using Pos.Service.Service;

namespace Pos.Api.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly Rol_Service _rolService;
        private readonly IMapper _mapper;

        public RolController(Rol_Service rol_service, IMapper mapper)
        {
            _rolService = rol_service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolDto>>> GetAll()
        {
            try
            {
                var entidad = await _rolService.GetAll();
                var entidadDto = _mapper.Map<List<RolDto>>(entidad);
                return Ok(entidadDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener el listado de registros.", ex.Message });
            }
        }
    }
}
