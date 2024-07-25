using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetBoilerplate.Core.Employees;

namespace DotNetBoilerplate.Core.Questions
{
    public interface IQuestionRepository
    {
        Task<Question?> GetByIdAsync(Guid id);
        Task<List<Question>> GetAllAsync();
        Task AddAsync(Question question);

        Task<IEnumerable<Question>> GetQuestionsByFormIdAsync(Guid formId, CancellationToken ct);
    }
}
