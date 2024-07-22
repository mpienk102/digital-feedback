using DotNetBoilerplate.Shared.Abstractions.Exceptions;


namespace DotNetBoilerplate.Application.Organizations.Exceptions
{
    internal class AdminIsInDifferentOrganizationException : CustomException
    {
        public AdminIsInDifferentOrganizationException() : base("Admin is in other organization")
        {

        }
    }
}
