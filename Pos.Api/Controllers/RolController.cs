﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql;
using Pos.Dto.Dto;
using Pos.Model.Models;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<RolDto>> GetById(int id)
        {
            try
            {
                var entidad = await _rolService.GetByID(id);
                if (entidad == null) {
                    return NotFound(new { StatusCode = 404, message = "Registro no encontrado." });
                }
                return Ok(_mapper.Map<RolDto>(entidad));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, message = "Error al obtener el registro.", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RolDto rolDto)
        {
            try
            {
                var entidad = _mapper.Map<Rol>(rolDto);
                var entidadCreada = await _rolService.Create(entidad);
                return Ok(new { StatusCode = 200, message = "Registro creado con éxito.", data = _mapper.Map<RolDto>(entidadCreada) });
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is PostgresException pgEx && pgEx.SqlState == "23505")
                {
                    return BadRequest(new { StatusCode = 400, message = "Ya existe un registro con la misma descripción. Inténtelo de nuevo. " });
                }
                return StatusCode(500, new { StatusCode = 500, message = "Error al crear el registro.", error = ex.InnerException?.Message ?? ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, message = "Error al crear el registro", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update (int id, [FromBody] RolDto rolDto)
        {
            try
            {
                if(id != rolDto.IdRol)
                {
                    return BadRequest(new { StatusCode = 400, message = "El ID del registro no coincide." });
                }
                var entidad = _mapper.Map<Rol>(rolDto);
                var entidadActualizada = await _rolService.Update(entidad);
                return Ok( new {StatusCode = 200, message = "Registro actualizado con éxtio", data = _mapper.Map<RolDto>(entidadActualizada)});
            }catch(KeyNotFoundException ex)
            {
                return NotFound(new {StatusCode = 404, message = ex.Message});
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is PostgresException pgEx && pgEx.SqlState == "23505")
                {
                    return BadRequest(new { StatusCode = 400, message = "Ya existe un registro con la misma descripción. Inténtelo de nuevo. " });
                }
                return StatusCode(500, new { StatusCode = 500, message = "Error al actualizar el registro.", error = ex.InnerException?.Message ?? ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, message = "Error a actualizar el registro", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var resultado = await _rolService.Delete(id);
                if (!resultado)
                {
                    return NotFound(new { StatusCode = 404, message = "Registro no encontrado." });
                }
                return Ok(new { StatusCode = 200, message = "Registro eliminado satisfactoriamente." });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, message = "Error al eliminar el registro.", error = ex.Message });
            }
        }


    }
}
