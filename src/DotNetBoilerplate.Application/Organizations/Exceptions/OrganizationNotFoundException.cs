using DotNetBoilerplate.Shared.Abstractions.Exceptions;


namespace DotNetBoilerplate.Application.Organizations.Exceptions
{
    internal class OrganizationNotFoundException : CustomException
    {
        public OrganizationNotFoundException(Guid organizationId) : base($"Organization {organizationId} not found.")
        {
            
        }
    }
}
