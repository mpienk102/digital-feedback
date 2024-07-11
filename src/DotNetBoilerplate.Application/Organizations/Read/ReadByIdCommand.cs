using DotNetBoilerplate.Shared.Abstractions.Commands;
using System.Windows.Input;

namespace DotNetBoilerplate.Application.Organizations.Read
{
    public record ReadByIdCommand(Guid Id) : ICommand<OrganizationDto>;
}
