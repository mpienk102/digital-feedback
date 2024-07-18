namespace DotNetBoilerplate.Api.Employees
{
    internal static class EmployeesEndpoints
    {
        public const string BasePath = "employees";
        public const string Tags = "Employees";

        public static void MapEmployeesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup(BasePath).WithTags(Tags);

            group
                .MapEndpoint<CreateEmployeeEndpoint>()
                .MapEndpoint<BrowseEmployeesEndpoint>()
                .MapEndpoint<GetEmployeeByIdEndpoint>()
                .MapEndpoint<UpdateRoleEmployeeEndpoint>()
                .MapEndpoint<DeleteEmployeeFromOrganizationEndpoint>();
        }
    }
}
