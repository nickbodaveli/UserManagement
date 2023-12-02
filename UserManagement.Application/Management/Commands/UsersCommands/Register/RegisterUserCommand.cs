using MediatR;
using UserManagement.Domain;

namespace UserManagement.Application.Management.Commands.UsersCommands.Register
{
    public class RegisterUserCommand : IRequest<User>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
