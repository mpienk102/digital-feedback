using System.Formats.Asn1;

namespace DotNetBoilerplate.Core.Answers;

internal sealed class InMemoryAnswerRepository : IAnswerRepository
{
    private readonly List<Answer> answers = [];
    public Task AddAsync(Answer answer)
    {
        answers.Add(answer);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Answer answer)
    {
        answers.Remove(answer);
        return Task.CompletedTask;
    }

    public Task<List<Answer>> GetAllAsync()
    {
        return Task.FromResult(answers);
    }

    public Task<Answer> GetByIdAsync(Guid id)
    {
        var answer = answers.Find(x => x.Id == id);
        return Task.FromResult(answer);
    }

    public Task UpdateAsync(Answer answer)
    {
        var index = answers.FindIndex(x => x.Id == answer.Id);
        answers[index] = answer;
        return Task.CompletedTask;
    }

    public Task<List<Answer>> BrowseByFormId(Guid formId)
    {
        var questionAnswers = answers.Where(x => x.FormId == formId).ToList();
        return Task.FromResult(questionAnswers);
    }
}