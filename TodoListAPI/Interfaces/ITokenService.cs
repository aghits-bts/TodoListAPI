using TodoListAPI.Models;

namespace TodoListAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
