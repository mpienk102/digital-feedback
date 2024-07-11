using DotNetBoilerplate.Shared.Abstractions.Exceptions;


namespace DotNetBoilerplate.Application.Projects.Exceptions
{
    internal class ProjectNotFoundException : CustomException
    {
        public ProjectNotFoundException(Guid projectId) : base($"Project {projectId} not found.")
        {

        }
    }
}
