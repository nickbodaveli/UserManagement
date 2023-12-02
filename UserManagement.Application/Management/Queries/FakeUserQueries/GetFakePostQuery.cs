using MediatR;

namespace UserManagement.Application.Management.Queries.FakeUserQueries
{
    public class GetFakePostQuery : IRequest<string>
    {
        public int UserId { get; set; }
    }
}
