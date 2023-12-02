using MediatR;
using UserManagement.Application.Common.Interfaces;
using UserManagement.Domain;

namespace UserManagement.Application.Management.Commands.UsersProfileCommands
{
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UserProfile>
    {
        private readonly IUserProfileManagementRepository _userProfileManagementRepository;
        private readonly IUserManagementRepository _userManagementRepository;

        public UpdateUserProfileCommandHandler(IUserProfileManagementRepository userProfileManagementRepository, IUserManagementRepository userManagementRepository)
        {
            _userProfileManagementRepository = userProfileManagementRepository;
            _userManagementRepository = userManagementRepository;
        }

        public async Task<UserProfile> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManagementRepository.GetUser(request.UserId);

            if(user == null)
            {
                throw new Exception("Please use correct UserId");
            }

            var result = await _userProfileManagementRepository.UpdateUserProfile(request);

            return result;
        }
    }
}
