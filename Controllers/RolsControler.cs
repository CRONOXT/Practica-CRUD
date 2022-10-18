using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica_CRUD.Class;
using Practica_CRUD.Class.ClassDto;
using Practica_CRUD.Data;
using Practica_CRUD.Services;

namespace Practica_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolsControler : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly RolServices _rolServices;
        public RolsControler(DataContext dataContext, RolServices rolServices)
        {
            _dataContext = dataContext;
            _rolServices = rolServices;
        }

        [HttpGet]
        public async Task<IEnumerable<Rol>> Get()
        {
            return await _rolServices.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> GetById(int id)
        {
            var rol = await _rolServices.GetById(id);

            if (rol is null)
                return NotFound(id);

            return rol;
        }

        [HttpPost]
        public async Task<IActionResult> Create(RolDto Rol)
        {
            var newRol = await _rolServices.Create(Rol);
            return CreatedAtAction(nameof(GetById), new { id = newRol.Id }, newRol);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,RolDto rols)
        {
            if (id != rols.Id)
                return BadRequest(new { message = $"El ID ({id}) de la URL no coincide con algun ID" });

            var rolToUpdate = await _rolServices.GetById(id);

            if (rolToUpdate is not null)
            {
                await _rolServices.Update(rols);
                return NoContent();
            }
            else
            {
                return NotFound(id);
            }
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete(int id)
        {
            var rolDeleted = await _rolServices.GetById(id);

            if(rolDeleted is not null)
            {
                await _rolServices.Delete(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
