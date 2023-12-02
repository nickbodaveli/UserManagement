using FluentValidation;
using MediatR;
using System.Text.RegularExpressions;
using UserManagement.Domain;

namespace UserManagement.Application.Management.Commands.UsersProfileCommands
{
    public class CreateUserProfileCommand : IRequest<UserProfile>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
    }

    public class UserProfileValidation : AbstractValidator<CreateUserProfileCommand>
    {
        public UserProfileValidation()
        {
            RuleFor(x => x.PersonalNumber)
                .NotNull()
                .WithMessage("Cannot be null")
                .NotEmpty()
                .WithMessage("Cannot be empty")
                .Matches(new Regex(@"^\d{11}$"))
                .WithMessage("Personal Number must contain 11 symbols");
        }
    }
}
