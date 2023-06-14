using FluentValidation;

namespace ApiPracitce.Dtos.AccountDtos
{
    public class LoginDto
    {
        public string Number { get; set; }
        public string Password { get; set; }
    }

    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Number).NotNull().NotEmpty().MaximumLength(25).MinimumLength(5);
            RuleFor(x => x.Password).NotNull().NotEmpty().MaximumLength(25).MinimumLength(5);
        }
    }
}
