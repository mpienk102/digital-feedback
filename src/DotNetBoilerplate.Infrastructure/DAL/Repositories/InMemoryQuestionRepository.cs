using DotNetBoilerplate.Core.Questions;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories
{
    internal class InMemoryQuestionRepository : IQuestionRepository
    {
        private readonly List<Question> questions = [];

        public Task<Question> GetByIdAsync(Guid id)
        {
            var question = questions.Find(x => x.Id == id);

            return Task.FromResult(question);
        }

        public Task AddAsync(Question question)
        {
            questions.Add(question);

            return Task.CompletedTask;
        }

        public Task<List<Question>> GetAllAsync()
        {
            return Task.FromResult(questions);
        }
    }
}
