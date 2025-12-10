using Microsoft.AspNetCore.Mvc;
using veterinaria.infretruture.DBContex;
using veterinaria.infretruture.Model;
using Veterinaria.Aplication.DTOS;
using tallermecanico.domain.Entityes;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PropietarioController : ControllerBase
    {
        private readonly VeterinariaContex _context;

        public PropietarioController(VeterinariaContex context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllPropietarios()
        {
            var propietarios = _context.Propietarios.ToList();

            var dtoList = propietarios.Select(p => new PropietarioDto
            {
                PropietatioId = p.PropietatioId,
                Nombre = p.Nombre,
                Cedula = p.Cedula,
                Telefono = p.Telefono,
                Direccion = p.Direccion
            }).ToList();

            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public IActionResult GetPropietarioById(int id)
        {
            var propietario = _context.Propietarios.FirstOrDefault(p => p.PropietatioId == id);
            if (propietario == null)
                return NotFound();

            return Ok(propietario);
        }

        [HttpPost]
        public IActionResult CreatePropietario([FromBody] PropietarioDto dto)
        {
            var propietario = new PropietarioModel
            {
                PropietatioId = dto.PropietatioId,
                Nombre = dto.Nombre,
                Cedula = dto.Cedula,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion
            };

            _context.Add(propietario);
            _context.SaveChanges();

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePropietario(int id, [FromBody] PropietarioDto dto)
        {
            var propietario = _context.Propietarios.FirstOrDefault(p => p.PropietatioId == id);
            if (propietario == null)
                return NotFound();

            propietario.Nombre = dto.Nombre;
            propietario.Cedula = dto.Cedula;
            propietario.Telefono = dto.Telefono;
            propietario.Direccion = dto.Direccion;

            _context.Update(propietario);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePropietario(int id)
        {
            var propietario = _context.Propietarios.FirstOrDefault(p => p.PropietatioId == id);
            if (propietario == null)
                return NotFound();

            _context.Propietarios.Remove(propietario);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
