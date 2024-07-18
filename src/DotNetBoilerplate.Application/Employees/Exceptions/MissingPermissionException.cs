using DotNetBoilerplate.Core.Users;
using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Application.Employees.Exceptions;

public sealed class MissingPermissionException : CustomException
{
    public MissingPermissionException() : base("Role can only be updated to None or Moderator.")
    {
    }
}