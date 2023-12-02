using MediatR;
using UserManagement.Application.Common.Interfaces;

namespace UserManagement.Application.Management.Commands.Authentication
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IUserManagementRepository _userManagementRepository;
        private readonly IHelperRepository _helperRepository;

        public LoginCommandHandler(IUserManagementRepository userManagementRepository, IHelperRepository helperRepository)
        {
            _userManagementRepository = userManagementRepository;
            _helperRepository = helperRepository;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {

            var user = await _userManagementRepository.GetUserByEmail(request.Email);

            bool verified = _helperRepository.Verify(request.Password, user.Password);

            if (!verified)
            {
                throw new Exception("Password isn't verified!");
            }

            string token = _helperRepository.GenerateJWTToken(user);

            return token;
        }
    }
}
