using MediatR;

namespace UserManagement.Application.Management.Commands.UsersProfileCommands
{
    public class RemoveUserProfileCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
