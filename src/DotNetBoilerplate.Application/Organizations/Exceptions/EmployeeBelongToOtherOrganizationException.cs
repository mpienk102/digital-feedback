using DotNetBoilerplate.Shared.Abstractions.Exceptions;


namespace DotNetBoilerplate.Application.Organizations.Exceptions
{
    internal class EmployeeBelongToOtherOrganizationException : CustomException
    {
        public EmployeeBelongToOtherOrganizationException() : base("Employee belongs the other organization")
        {

        }
    }
}
