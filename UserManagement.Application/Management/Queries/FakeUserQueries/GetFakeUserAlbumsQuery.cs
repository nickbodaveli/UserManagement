using MediatR;

namespace UserManagement.Application.Management.Queries.FakeUserQueries
{
    public class GetFakeUserAlbumsQuery : IRequest<string>
    {
        public int UserId { get; set; }
    }
}
