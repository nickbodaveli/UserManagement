using MediatR;
using UserManagement.Domain;

namespace UserManagement.Application.Management.Queries.UsersProfileQueries
{
    public class UserProfilesQuery : IRequest<IEnumerable<UserProfile>>
    {
    }
}
