using MediatR;
using FluentValidation.Results;

namespace UserService.Application.CQRS.Command.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, ServiceResult>
    {
        private readonly CreateUser _createUser;

        public CreateUserHandler(CreateUser createUser)
        {
            _createUser = createUser;
        }

        public async Task<ServiceResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Создаем валидатор и выполняем валидацию
            CreateUserValidator validator = new CreateUserValidator(request.createUser.DeviceType);
            ValidationResult results = await validator.ValidateAsync(request.createUser);

            if (!results.IsValid)
            {
                return new ServiceResult()
                {
                    IsSuccesful = false,
                    ErrorMsg = string.Join("; ", results.Errors.Select(e => e.ErrorMessage))
                };
            }

            ServiceResult result = await _createUser.CreateUserAsync(request.createUser);
            return result;
        }
    }
}
