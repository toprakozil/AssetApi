using FluentValidation;

namespace Application.Models.User
{
    public class LoginUserPayloadValidation : AbstractValidator<LoginUserPayload>
    {
        public LoginUserPayloadValidation()
        {
            RuleFor(c => c.UserName).NotNull().NotEmpty().WithMessage("Username must have a value");
            RuleFor(c => c.Password).NotNull().NotEmpty().WithMessage("Password must have a value");
        }
    }
}
