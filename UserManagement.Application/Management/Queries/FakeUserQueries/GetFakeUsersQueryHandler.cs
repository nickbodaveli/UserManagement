using MediatR;
using UserManagement.Application.Common.Interfaces;

namespace UserManagement.Application.Management.Queries.FakeUserQueries
{
    public class GetFakeUsersQueryHandler : IRequestHandler<GetFakeUsersQuery, string>
    {
        private readonly IFakeRepository _fakeRepository;

        public GetFakeUsersQueryHandler(IFakeRepository fakeRepository)
        {
            _fakeRepository = fakeRepository;
        }

        public async Task<string> Handle(GetFakeUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _fakeRepository.Users();

            return result;
        }
    }
}
