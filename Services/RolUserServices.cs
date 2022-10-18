using AutoMapper;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore;
using Practica_CRUD.Class;
using Practica_CRUD.Class.ClassDto;
using Practica_CRUD.Data;

namespace Practica_CRUD.Services
{
    public class RolUserServices
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public RolUserServices(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RolUser>> GetAll()
        {
            return await _context.RolUser.ToListAsync();
        }
        public async Task<RolUser?> GetById(int id)
        {
            return await _context.RolUser.FindAsync(id);
        }
    }
}
