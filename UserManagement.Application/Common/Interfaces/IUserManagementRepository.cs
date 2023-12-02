using UserManagement.Application.Management.Commands.UsersCommands.Register;
using UserManagement.Domain;

namespace UserManagement.Application.Common.Interfaces
{
    public interface IUserManagementRepository
    {
        Task<User> RegisterUser(RegisterUserCommand request);
        Task<User> GetUser(int request);
        Task<User> GetUserByEmail(string request);
    }
}
