using DotNetBoilerplate.Core.Users;
using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Application.Exceptions;

public sealed class UserNotFoundException : CustomException
{
    public UserNotFoundException(Guid userId) : base($"User {userId} not found")
    {
    }
}