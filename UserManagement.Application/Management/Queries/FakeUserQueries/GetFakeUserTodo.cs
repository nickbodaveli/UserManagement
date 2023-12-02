using MediatR;

namespace UserManagement.Application.Management.Queries.FakeUserQueries
{
    public class GetFakeUserTodo : IRequest<string>
    {
        public int UserId { get; set; }
    }
}
