using FluentValidation;
using MediatR;

namespace UserManagement.Application.Management.Commands.Authentication
{
    public class LoginCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginDataValidation : AbstractValidator<LoginCommand>
    {
        public LoginDataValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Required")
                .EmailAddress()
                .WithMessage("Email must be correct");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Required");
        }
    }
}
