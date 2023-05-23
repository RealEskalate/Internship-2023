using Microsoft.AspNetCore.Identity;

namespace CineFlex.Application.Exceptions;

public class IdentityException : ApplicationException
{
    public List<IdentityError> Errors { get; }

    public IdentityException(string message, List<IdentityError> errors) : base(message)
    {
        Errors = errors;
    }
}