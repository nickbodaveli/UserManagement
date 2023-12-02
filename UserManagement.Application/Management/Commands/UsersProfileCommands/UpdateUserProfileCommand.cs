using MediatR;
using UserManagement.Domain;

namespace UserManagement.Application.Management.Commands.UsersProfileCommands
{
    public class UpdateUserProfileCommand : IRequest<UserProfile>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
    }
}
