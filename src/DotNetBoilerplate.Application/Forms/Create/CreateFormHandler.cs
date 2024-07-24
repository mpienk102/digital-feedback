using DotNetBoilerplate.Application.Employees.Create;
using DotNetBoilerplate.Core.Forms;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;
using DotNetBoilerplate.Shared.Abstractions.Time;

namespace DotNetBoilerplate.Application.Forms.Create
{
    internal sealed class CreateFromHandler(
        IFormRepository formRepository,
        IContext context,
        IClock clock
        ) : ICommandHandler<CreateFormCommand, Guid>
    {
        public async Task<Guid> HandleAsync(CreateFormCommand command)
        {
            var form = Form.Create(
                command.name,
                command.description,
                context.Identity.Id,
                clock.Now()
            );
            await formRepository.AddAsync(form);

            return form.Id;
        }
    }
}
