using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.Organizations.Exceptions
{
    internal sealed class UserInOrganizationException() : CustomException("User already has a role in another organization")
    {

    }
}
