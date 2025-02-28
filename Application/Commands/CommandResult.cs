using System.Net;

using Application.DTOs.Response;
using Application.Commands.Contracts;

namespace Application.Commands
{
    public class CommandResult<T> : ICommandResult
    {

        public ApiResponseModel<T> Response { get; private set; }

        public CommandResult(T data, HttpStatusCode statusCode, string message = "")
        {
            Response = new ApiResponseModel<T>
            {
                Data = data,
                Status = statusCode,
                Message = string.IsNullOrEmpty(message) ? GetDefaultMessage(statusCode) : message
            };
        }

        private string GetDefaultMessage(HttpStatusCode statusCode)
        {
            return statusCode switch
            {
                HttpStatusCode.OK => "Operation completed successfully.",
                HttpStatusCode.Created => "Resource created successfully.",
                HttpStatusCode.BadRequest => "There was an issue with the request.",
                HttpStatusCode.NotFound => "Resource not found.",
                _ => "An error occurred during the operation."
            };
        }

        public static CommandResult<T> Success(T data, HttpStatusCode statusCode = HttpStatusCode.OK, string message = "")
        {
            return new CommandResult<T>(data, statusCode, message);
        }

        public static CommandResult<T> Failure(HttpStatusCode statusCode, string message)
        {
            return new CommandResult<T>(default, statusCode, message);
        }
    }

}
