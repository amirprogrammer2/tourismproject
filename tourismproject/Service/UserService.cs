using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tourismproject.Data;
using tourismproject.Dto;
using tourismproject.Entity;
using tourismproject.repository;
namespace tourismproject.Service
{
    public class UserService : IUserSrvice
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _Mapper;
        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _Mapper = mapper;
        }
        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Username == dto.Username))
                return false;
                
            var user = _Mapper.Map<User>(dto);
            user.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
        
        public async Task<User>LoginAsync(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                return null;
            return user;
        }
        
    }
}
