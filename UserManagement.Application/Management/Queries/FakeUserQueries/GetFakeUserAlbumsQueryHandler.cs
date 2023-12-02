using MediatR;
using UserManagement.Application.Common.Interfaces;

namespace UserManagement.Application.Management.Queries.FakeUserQueries
{
    public class GetFakeUserAlbumsQueryHandler : IRequestHandler<GetFakeUserAlbumsQuery, string>
    {
        private readonly IFakeRepository _fakeRepository;

        public GetFakeUserAlbumsQueryHandler(IFakeRepository fakeRepository)
        {
            _fakeRepository = fakeRepository;
        }

        public async Task<string> Handle(GetFakeUserAlbumsQuery request, CancellationToken cancellationToken)
        {
            var result = await _fakeRepository.Album(request.UserId);

            return result;
        }
    }
}
