using MediatR;
using UserManagement.Domain;

namespace UserManagement.Application.Management.Queries.UsersProfileQueries
{
    public class UserProfileQuery : IRequest<UserProfile>
    {
        public int Id { get; set; }
    }
}
