using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Practica_CRUD.Class;
using Practica_CRUD.Class.ClassDto;
using Practica_CRUD.Data;

namespace Practica_CRUD.Services
{
    public class UserServices
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserServices(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.User.ToListAsync();
        }
        public async Task<User?> GetById (int id)
        {
            return await _context.User.FindAsync(id);
        }
        public async Task<User> Create(UserDto newUserDto)
        {
            var newUser = _mapper.Map<User>(newUserDto);

            _context.User.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }
    }
}
