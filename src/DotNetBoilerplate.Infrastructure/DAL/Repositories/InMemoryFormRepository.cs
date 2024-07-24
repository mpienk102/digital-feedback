using DotNetBoilerplate.Core.Forms;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories;

internal sealed class InMemoryFormRepository : IFormRepository
{
    private readonly List<Form> forms = [];


    public Task<Form> GetByIdAsync(Guid id)
    {
        var Form = forms.Find(x => x.Id == id);

        return Task.FromResult(Form);
    }

    public Task AddAsync(Form form)
    {
        forms.Add(form);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Form Form)
    {
        var index = forms.FindIndex(x => x.Id == Form.Id);
        forms[index] = Form;

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Form Form)
    {
        throw new NotImplementedException();
    }

    public Task<List<Form>> GetAllAsync()
    {
        return Task.FromResult(forms);
    }
}