using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using System.Windows.Input;

namespace DotNetBoilerplate.Application.Organizations.Read
{
    public record GetByIdQuery(Guid Id) : IQuery<OrganizationDto>;
}
