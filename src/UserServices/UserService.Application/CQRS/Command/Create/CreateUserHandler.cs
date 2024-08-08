using MediatR;
using FluentValidation.Results;
using UserService.Application.Interface;

namespace UserService.Application.CQRS.Command.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand,ServiceResult>
    {
        private readonly ICreateUserService _createUser;
        private readonly CreateUserValidatorFactory _validatorFactory;

        public CreateUserHandler(ICreateUserService createUser, CreateUserValidatorFactory validatorFactory)
        {
            _createUser = createUser;
          
            _validatorFactory = validatorFactory;
        }

        public async Task<ServiceResult> Handle(CreateUserCommand request,CancellationToken cancellationToken)
        {
            var validator = _validatorFactory.Create();

            ValidationResult results = await validator.ValidateAsync(request.createUser, cancellationToken);

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
