using DotNetBoilerplate.Shared.Abstractions.Exceptions;


namespace DotNetBoilerplate.Application.Organizations.Exceptions
{
    internal class MissingAdminRoleException : CustomException
    {
        public MissingAdminRoleException(Guid organizationId) : base($"You are not an admin of {organizationId} organization.")
        {

        }
    }
}
