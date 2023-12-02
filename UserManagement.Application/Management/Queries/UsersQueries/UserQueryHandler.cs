using MediatR;
using UserManagement.Application.Common.Interfaces;
using UserManagement.Domain;

namespace UserManagement.Application.Management.Queries.UsersQueries
{
    public class UserQueryHandler : IRequestHandler<UserQuery, User>
    {
        private readonly IUserManagementRepository _userManagementRepository;

        public UserQueryHandler(IUserManagementRepository userManagementRepository)
        {
            _userManagementRepository = userManagementRepository;
        }

        public async Task<User> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            var result = await _userManagementRepository.GetUser(request.Id);

            return result;
        }
    }
}
