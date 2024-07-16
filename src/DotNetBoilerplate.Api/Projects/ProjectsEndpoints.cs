namespace DotNetBoilerplate.Api.Projects
{
    internal static class ProjectsEndpoints
    {
        public const string BasePath = "projects";
        public const string Tags = "Projects";

        public static void MapProjectsEndpoints(this WebApplication app)
        {
            var group = app.MapGroup(BasePath).WithTags(Tags);

            group
                .MapEndpoint<CreateProjectEndpoint>()
                .MapEndpoint<BrowseProjectsEndpoint>()
                .MapEndpoint<GetProjectByIdEndpoint>()
                .MapEndpoint<UpdateProjectEndpoint>()
                .MapEndpoint<UpdateProjectStatusEndpoint>()
                .MapEndpoint<DeleteProjectEndpoint>();
        }   
    }
}
