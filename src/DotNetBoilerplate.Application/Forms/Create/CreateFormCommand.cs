using System.Windows.Input;
using DotNetBoilerplate.Core.Forms;
using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Forms.Create
{
    public sealed record CreateFormCommand(string Name, string Description, Guid ProjectId) : ICommand<Guid>;
}
