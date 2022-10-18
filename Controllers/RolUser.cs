using AutoMapper;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica_CRUD.Class;
using Practica_CRUD.Class.ClassDto;
using Practica_CRUD.Data;
using Practica_CRUD.Mapper;
using Practica_CRUD.Services;

namespace Practica_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolUser : ControllerBase
    {
        private readonly DataContext _context;
        private readonly RolUserServices _rolUserServices;
        private readonly IMapper _mapper;
        public RolUser(DataContext context, RolUserServices rolUserServices, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _rolUserServices = rolUserServices;
        }

        [HttpGet]
        public async Task<IEnumerable<Class.RolUser>> Get()
        {
            return await _rolUserServices.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Class.RolUser>> GetById(int id)
        {
            var rolUser = await _rolUserServices.GetById(id);

            if (rolUser is null)
                return NotFound(id);

            return rolUser;
        }
        [HttpPost]
        public async Task<ActionResult<Class.RolUser>> Create(RolUserDto user)
        {
            var newUserRol = _mapper.Map<Class.RolUser>(user);
            _context.RolUser.Add(newUserRol);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RolUserExists(newUserRol.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetById", new { id = newUserRol.UserId }, newUserRol);
        }

        private bool RolUserExists(int id)
        {
            return _context.RolUser.Any(e => e.UserId == id);
        }
    }
}
