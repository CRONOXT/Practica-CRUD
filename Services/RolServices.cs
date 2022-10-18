using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Practica_CRUD.Class.ClassDto;
using Practica_CRUD.Class;
using Practica_CRUD.Data;

namespace Practica_CRUD.Services
{
    public class RolServices
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public RolServices(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Rol>> GetAll()
        {
            return await _context.Rol.ToListAsync();
        }
        public async Task<Rol?> GetById(int id)
        {
            return await _context.Rol.FindAsync(id);
        }
        public async Task<Rol> Create(RolDto newRolDto)
        {
            var newRol = _mapper.Map<Rol>(newRolDto);

            _context.Rol.Add(newRol);
            await _context.SaveChangesAsync();
            return newRol;
        }
        public async Task Update(RolDto rols)
        {
            var existRol = await GetById(rols.Id);

            if(existRol is not null)
            {
                existRol.Name = rols.Name;
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var existRol = await GetById(id);

            if (existRol is not null)
            {
                _context.Rol.Remove(existRol);
                await _context.SaveChangesAsync();
            }
        }


    }
}
