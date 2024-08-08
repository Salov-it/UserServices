using FluentValidation;
using UserService.Application.Dto;

namespace UserService.Application.CQRS.Command.Create
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {

        public void SetDeviceType(string deviceType)
        {
            ApplyRulesForDeviceType(deviceType);
        }

        private void ApplyRulesForDeviceType(string deviceType)
        {
            switch (deviceType.ToLower())
            {
                case "mail":
                    ApplyMailRules();
                    break;

                case "mobile":
                    ApplyMobileRules();
                    break;

                case "web":
                    ApplyWebRules();
                    break;

                default:
                    throw new ArgumentException("Invalid device type");
            }
        }

        private void ApplyMailRules()
        {
            RuleFor(user => user.FirstName)
                .NotEmpty()
                .WithMessage("FirstName is required for device type 'mail'.");

            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("Email is required for device type 'mail'.");
        }

        private void ApplyMobileRules()
        {
            RuleFor(user => user.Phone)
                .NotEmpty()
                .WithMessage("Phone is required for device type 'mobile'.");
        }

        private void ApplyWebRules()
        {
            RuleFor(user => user.LastName)
                .NotEmpty()
                .WithMessage("LastName is required for device type 'web'.");

            RuleFor(user => user.FirstName)
                .NotEmpty()
                .WithMessage("FirstName is required for device type 'web'.");

            RuleFor(user => user.MiddleName)
                .NotEmpty()
                .WithMessage("MiddleName is required for device type 'web'.");

            RuleFor(user => user.DateOfBirth)
                .NotEmpty()
                .WithMessage("DateOfBirth is required for device type 'web'.");

            RuleFor(user => user.PassportNumber)
                .NotEmpty()
                .WithMessage("PassportNumber is required for device type 'web'.");

            RuleFor(user => user.PlaceOfBirth)
                .NotEmpty()
                .WithMessage("PlaceOfBirth is required for device type 'web'.");

            RuleFor(user => user.Phone)
                .NotEmpty()
                .WithMessage("Phone is required for device type 'web'.");

            RuleFor(user => user.RegistrationAddress)
                .NotEmpty()
                .WithMessage("RegistrationAddress is required for device type 'web'.");
        }
    }
    
}
