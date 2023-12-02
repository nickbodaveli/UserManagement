using MediatR;
using UserManagement.Application.Common.Interfaces;
using UserManagement.Domain;

namespace UserManagement.Application.Management.Queries.UsersProfileQueries
{
    public class UserProfileQueryHandler : IRequestHandler<UserProfileQuery, UserProfile>
    {
        private readonly IUserProfileManagementRepository _userProfileManagementRepository;

        public UserProfileQueryHandler(IUserProfileManagementRepository userProfileManagementRepository)
        {
            _userProfileManagementRepository = userProfileManagementRepository;
        }

        public async Task<UserProfile> Handle(UserProfileQuery request, CancellationToken cancellationToken)
        {
            var result = await _userProfileManagementRepository.GetUserProfile(request.Id);

            return result;
        }
    }
}
