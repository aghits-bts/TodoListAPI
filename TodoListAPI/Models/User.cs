using Microsoft.AspNetCore.Identity;

namespace TodoListAPI.Models
{
    public class User : IdentityUser
    {
        public List<Todo> Todos { get; set; } = new List<Todo>();
    }
}
