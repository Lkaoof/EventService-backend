using FluentValidation;

namespace EventPlatform.Application.Features.Users.Command.UpdateById
{
    public class UpdateUserValidation : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidation()
        {
            RuleFor(u => u.User.PhoneNumber)
                .NotEmpty()
                .WithMessage("Number must not be empty");

            RuleFor(u => u.User.Name)
                .NotEmpty()
                .WithMessage("Username must not be empty");
        }
    }
}
