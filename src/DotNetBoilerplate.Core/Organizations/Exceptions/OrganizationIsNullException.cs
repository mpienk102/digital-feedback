using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.Organizations.Exceptions
{
    public sealed class OrganizationIsNullException(Guid Id) : CustomException($"Organization {Id} does not exist")
    {

    }
}
