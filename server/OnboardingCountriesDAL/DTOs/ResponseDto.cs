
namespace OnboardingCountriesDAL.DTOs
{
    public class ResponseDto<T>
    {
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class ResponseHandler
    {
        public static ResponseDto<T> CreateResponse<T>(T data, string errorMessage)
        {
            return new ResponseDto<T>
            {
                Data = data,
                ErrorMessage = errorMessage
            };
        }
    }
}
