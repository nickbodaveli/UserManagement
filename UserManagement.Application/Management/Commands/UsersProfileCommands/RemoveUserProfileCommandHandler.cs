using MediatR;
using UserManagement.Application.Common.Interfaces;

namespace UserManagement.Application.Management.Commands.UsersProfileCommands
{
    public class RemoveUserProfileCommandHandler : IRequestHandler<RemoveUserProfileCommand, bool>
    {
        private readonly IUserProfileManagementRepository _userProfileManagementRepository;

        public RemoveUserProfileCommandHandler(IUserProfileManagementRepository userProfileManagementRepository)
        {
            _userProfileManagementRepository = userProfileManagementRepository;
        }

        public async Task<bool> Handle(RemoveUserProfileCommand request, CancellationToken cancellationToken)
        {
            var result = await _userProfileManagementRepository.RemoveUserProfile(request.Id);
            return result;
        }
    }
}
