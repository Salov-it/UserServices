using FluentValidation;
using UserService.Application.Dto;

namespace UserService.Application.CQRS.Command.Create
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator(string deviceType) 
        {
            // Общие правила валидации
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName is required.")
                .MaximumLength(50).WithMessage("LastName must not exceed 50 characters.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName is required.")
                .MaximumLength(50).WithMessage("FirstName must not exceed 50 characters.");

            RuleFor(x => x.MiddleName)
                .MaximumLength(50).WithMessage("MiddleName must not exceed 50 characters.");

            RuleFor(x => x.DateOfBirth)
                .LessThan(DateTime.Now).WithMessage("DateOfBirth must be in the past.");

            RuleFor(x => x.PassportNumber)
                .Matches(@"^\d{4} \d{6}$").WithMessage("PassportNumber must be in the format XXXX XXXXXX.");

            RuleFor(x => x.PlaceOfBirth)
                .NotEmpty().WithMessage("PlaceOfBirth is required.")
                .MaximumLength(100).WithMessage("PlaceOfBirth must not exceed 100 characters.");

            RuleFor(x => x.Phone)
                .Matches(@"^7\d{10}$").WithMessage("Phone must be in the format 7XXXXXXXXXX.");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Email is not valid.")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.RegistrationAddress)
                .NotEmpty().WithMessage("RegistrationAddress is required.")
                .MaximumLength(200).WithMessage("RegistrationAddress must not exceed 200 characters.");

            RuleFor(x => x.ResidentialAddress)
                .MaximumLength(200).WithMessage("ResidentialAddress must not exceed 200 characters.")
                .When(x => !string.IsNullOrEmpty(x.ResidentialAddress));


            // Правила для mail
            When(user => deviceType == "mail", () =>
            {
                RuleFor(user => user.FirstName).NotEmpty().WithMessage("FirstName is required for device type 'mail'.");
                RuleFor(user => user.Email).NotEmpty().WithMessage("Email is required for device type 'mail'.");
            });

            // Правила для mobile
            When(user => deviceType == "mobile", () =>
            {
                RuleFor(user => user.Phone).NotEmpty().WithMessage("Phone is required for device type 'mobile'.");
            });

            // Правила для web
            When(user => deviceType == "web", () =>
            {
                RuleFor(user => user.LastName).NotEmpty().WithMessage("LastName is required for device type 'web'.");
                RuleFor(user => user.FirstName).NotEmpty().WithMessage("FirstName is required for device type 'web'.");
                RuleFor(user => user.MiddleName).NotEmpty().WithMessage("MiddleName is required for device type 'web'.");
                RuleFor(user => user.DateOfBirth).NotEmpty().WithMessage("DateOfBirth is required for device type 'web'.");
                RuleFor(user => user.PassportNumber).NotEmpty().WithMessage("PassportNumber is required for device type 'web'.");
                RuleFor(user => user.PlaceOfBirth).NotEmpty().WithMessage("PlaceOfBirth is required for device type 'web'.");
                RuleFor(user => user.Phone).NotEmpty().WithMessage("Phone is required for device type 'web'.");
                RuleFor(user => user.RegistrationAddress).NotEmpty().WithMessage("RegistrationAddress is required for device type 'web'.");
            });
        }
    }
}
