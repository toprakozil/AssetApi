using FluentValidation;

namespace Application.Models.User 
{
    public class AddUserPayloadValidation : AbstractValidator<AddUserPayload>
    {
        public AddUserPayloadValidation()
        {
            RuleFor(c => c.UserName).NotNull().NotEmpty().MaximumLength(100).WithMessage("Username must have a value");
            RuleFor(c => c.Name).NotNull().NotEmpty().MaximumLength(100).WithMessage("User must have a name");
            RuleFor(c => c.Password).NotNull().NotEmpty().MaximumLength(100).WithMessage("Password must have a value");
            When(c => !string.IsNullOrEmpty(c.Email), () =>
            {
                RuleFor(c => c.Email).EmailAddress();
            });
            

            //TODO: Check user context for the same username
        }
    }
}
