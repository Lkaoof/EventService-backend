using FluentValidation;

namespace EventPlatform.Application.Features.Users.Command.Create
{
    public class CreateUserValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidation()
        {
            RuleFor(u => u.PhoneNumber)
                .NotEmpty()
                .WithMessage("Number must not be empty");

            RuleFor(u => u.Password)
                .NotEmpty()
                .MinimumLength(8)
                .WithMessage("Password must be greater then 8")
                .MaximumLength(100)
                .WithMessage("Password must be less then 100");

            RuleFor(u => u.Name)
                .NotEmpty()
                .WithMessage("Username must not be empty");

            RuleFor(u => u.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email is incorrect");
        }
    }
}
