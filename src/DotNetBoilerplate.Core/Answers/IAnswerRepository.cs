namespace DotNetBoilerplate.Core.Answers;

public interface IAnswerRepository
{
    Task<Answer?> GetByIdAsync(Guid id);
    Task<List<Answer>> GetAllAsync();
    Task AddAsync(Answer answer);
    Task UpdateAsync(Answer answer);
    Task DeleteAsync(Answer answer);
    Task<List<Answer>> BrowseByFormId(Guid formId);
}