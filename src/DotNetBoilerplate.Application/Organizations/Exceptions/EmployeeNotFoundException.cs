using DotNetBoilerplate.Shared.Abstractions.Exceptions;


namespace DotNetBoilerplate.Application.Organizations.Exceptions
{
    internal class EmployeeNotFoundException : CustomException
    {
        public EmployeeNotFoundException(Guid employeeId) : base($"Employee {employeeId} not found.")
        {

        }
    }
}
