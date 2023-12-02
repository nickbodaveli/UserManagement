using MediatR;
using UserManagement.Domain;

namespace UserManagement.Application.Management.Queries.UsersQueries
{
    public class UserQuery : IRequest<User>
    {
        public int Id { get; set; }
    }
}
