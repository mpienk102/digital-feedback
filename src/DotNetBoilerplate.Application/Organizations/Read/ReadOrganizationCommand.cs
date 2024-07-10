using DotNetBoilerplate.Shared.Abstractions.Commands;
using System.Windows.Input;

namespace DotNetBoilerplate.Application.Organizations.Read
{
    public sealed class ReadOrganizationCommand : ICommand<List<OrganizationDto>>;
}
