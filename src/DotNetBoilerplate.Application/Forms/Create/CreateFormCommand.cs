using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Forms.Create
{
    public sealed record CreateFormCommand(string name, string description) : ICommand<Guid>;
}