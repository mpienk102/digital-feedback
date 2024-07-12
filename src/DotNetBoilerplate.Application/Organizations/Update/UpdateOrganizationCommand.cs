using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Organizations.Update
{
    public sealed record UpdateOrganizationCommand(Guid Id, Guid MemberId, string Name) : ICommand;
}
