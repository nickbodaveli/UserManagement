using MediatR;
using UserManagement.Application.Common.Interfaces;

namespace UserManagement.Application.Management.Queries.FakeUserQueries
{
    public class GetFakePostQueryHandler : IRequestHandler<GetFakePostQuery, string>
    {
        private readonly IFakeRepository _fakeRepository;

        public GetFakePostQueryHandler(IFakeRepository fakeRepository)
        {
            _fakeRepository = fakeRepository;
        }

        public async Task<string> Handle(GetFakePostQuery request, CancellationToken cancellationToken)
        {
            var result = await _fakeRepository.PostWithComments(request.UserId);

            return result;
        }
    }
}
