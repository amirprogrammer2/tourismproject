using tourismproject.Dto;
using tourismproject.Entity;

namespace tourismproject.repository
{
    public interface IUserSrvice
    {
        Task<bool> RegisterAsync(RegisterDto dto);
        Task<User> LoginAsync(LoginDto dto);

    }
}
