using Microsoft.EntityFrameworkCore;
using UserManagement.Application.Common.Interfaces;
using UserManagement.Application.Management.Commands.UsersCommands.Register;
using UserManagement.Domain;
using UserManagement.EFCore.Common;

namespace UserManagement.Infrastructure.Persistance.Repositories
{
    public class UserRepository : IUserManagementRepository
    {
        private readonly UserManagementDbContext _context;
        public UserRepository(UserManagementDbContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterUser(RegisterUserCommand request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

            if(user != null)
            {
                throw new Exception("User have already exists.");
            }

            var newUser = User.Create(request.UserName, request.Password, request.Email, request.IsActive);

            _context.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        public async Task<User> GetUser(int request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request);

            if(user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }

        public async Task<User> GetUserByEmail(string request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request);

            if (user == null)
            {
                throw new Exception("User not found by Email");
            }

            return user;
        }
    }
}
