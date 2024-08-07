

namespace UserService.Application.Dto
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }

}
