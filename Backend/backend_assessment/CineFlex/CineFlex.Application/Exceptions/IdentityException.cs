using Microsoft.AspNetCore.Identity;

namespace CineFlex.Application.Exceptions;

public class IdentityException : ApplicationException
{
    public IdentityException(string message, List<IdentityError> errors) : base(message)
    {
        Errors = errors;
    }

    public List<IdentityError> Errors { get; }
}