using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Models;

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