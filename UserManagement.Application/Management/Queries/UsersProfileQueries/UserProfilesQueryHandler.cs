using MediatR;
using UserManagement.Application.Common.Interfaces;
using UserManagement.Domain;

namespace UserManagement.Application.Management.Queries.UsersProfileQueries
{
    public class UserProfilesQueryHandler : IRequestHandler<UserProfilesQuery, IEnumerable<UserProfile>>
    {
        private readonly IUserProfileManagementRepository _userProfileManagementRepository;

        public UserProfilesQueryHandler(IUserProfileManagementRepository userProfileManagementRepository)
        {
            _userProfileManagementRepository = userProfileManagementRepository;
        }

        public async Task<IEnumerable<UserProfile>> Handle(UserProfilesQuery request, CancellationToken cancellationToken)
        {
            var result = await _userProfileManagementRepository.UserProfiles();

            return result;
        }
    }
}
