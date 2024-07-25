using System;
using System.Threading.Tasks;
using DotNetBoilerplate.Core.Forms;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;
using DotNetBoilerplate.Shared.Abstractions.Time;
using DotNetBoilerplate.Shared.Time;

namespace DotNetBoilerplate.Application.Forms.Create
{
    internal sealed class CreateFormHandler(
        IFormRepository formRepository,
        IContext context,
        IClock clock
    ) : ICommandHandler<CreateFormCommand, Guid>
    {
        public async Task<Guid> HandleAsync(CreateFormCommand command)
        {
            var form = Form.Create(
                command.Name,
                command.Description,
                context.Identity.Id,
                command.ProjectId,
                clock.Now()
            );

            await formRepository.AddAsync(form);

            return form.Id;
        }
    }
}
