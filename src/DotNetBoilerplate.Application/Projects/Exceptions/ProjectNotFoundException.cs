using DotNetBoilerplate.Shared.Abstractions.Exceptions;


namespace DotNetBoilerplate.Application.Project.Exceptions
{
    internal class ProjectNotFoundException : CustomException
    {
        public ProjectNotFoundException(Guid projectId) : base($"Project {projectId} not found.")
        {

        }
    }
}
