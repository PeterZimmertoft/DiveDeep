using DiveDeepWebApp.Api.DTOs;

namespace DiveDeepWebApp.Api.Mappers
{
    public static class ErrorMessage
    {
        public static ErrorMessageDTO ToDTO(this ErrorMessageException errorMessageException)
        {
            return new ErrorMessageDTO()
            {
                ErrorMessage = errorMessageException.Message,
            };
        }
    }
}