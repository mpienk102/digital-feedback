using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using System.Windows.Input;

namespace DotNetBoilerplate.Application.Organizations.Read
{
    public sealed class GetOrganizationQuery : IQuery<List<OrganizationDto>>;
}
