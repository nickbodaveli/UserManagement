using MediatR;
using UserManagement.Application.Common.Interfaces;

namespace UserManagement.Application.Management.Queries.FakeUserQueries
{
    public class GetFakeUserTodoHandler : IRequestHandler<GetFakeUserTodo, string>
    {
        private readonly IFakeRepository _fakeRepository;

        public GetFakeUserTodoHandler(IFakeRepository fakeRepository)
        {
            _fakeRepository = fakeRepository;
        }

        public async Task<string> Handle(GetFakeUserTodo request, CancellationToken cancellationToken)
        {
            var result = await _fakeRepository.Todos(request.UserId);

            return result;
        }
    }
}
