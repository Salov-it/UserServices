using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Application.CQRS.Command.Create
{
    public class CreateUserValidatorFactory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateUserValidatorFactory(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public CreateUserValidator Create()
        {
            var deviceType = _httpContextAccessor.HttpContext?.Request.Headers["x-Device"].FirstOrDefault() ?? "defaultDeviceType";
            var validator = new CreateUserValidator();
            validator.SetDeviceType(deviceType);
            return validator;
        }
    }
}

