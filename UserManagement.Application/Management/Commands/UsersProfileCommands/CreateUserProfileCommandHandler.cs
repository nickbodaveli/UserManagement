using MediatR;
using UserManagement.Application.Common.Interfaces;
using UserManagement.Domain;

namespace UserManagement.Application.Management.Commands.UsersProfileCommands
{
    public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, UserProfile>
    {
        private readonly IUserProfileManagementRepository _userProfileManagementRepository;
        private readonly IUserManagementRepository _userManagementRepository;

        public CreateUserProfileCommandHandler(IUserProfileManagementRepository userProfileManagementRepository, IUserManagementRepository userManagementRepository)
        {
            _userProfileManagementRepository = userProfileManagementRepository;
            _userManagementRepository = userManagementRepository;
        }

        public async Task<UserProfile> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManagementRepository.GetUser(request.UserId);

            var result = await _userProfileManagementRepository.CreateUserProfile(request);
            return result;
        }
    }
}
