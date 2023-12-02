using MediatR;
using UserManagement.Application.Common.Interfaces;
using UserManagement.Application.Management.Commands.UsersCommands.Register;
using UserManagement.Domain;

namespace UserManagement.Application.Management.Commands.UsersCommands.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private readonly IUserManagementRepository _userManagementRepository;
        private readonly IHelperRepository _helperRepository;

        public RegisterUserCommandHandler(IUserManagementRepository userManagementRepository, IHelperRepository helperRepository)
        {
            _userManagementRepository = userManagementRepository;
            _helperRepository = helperRepository;
        }

        public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            request.Password = _helperRepository.Encrypt(request.Password);

            var result = await _userManagementRepository.RegisterUser(request);
            return result;
        }
    }
}
