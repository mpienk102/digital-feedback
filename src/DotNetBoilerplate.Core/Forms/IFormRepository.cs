using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetBoilerplate.Core.Forms;

namespace DotNetBoilerplate.Core.Forms
{
    public interface IFormRepository
    {
        Task<Form?> GetByIdAsync(Guid id);

        Task<List<Form>> GetAllAsync();

        Task AddAsync(Form form);
        Task UpdateAsync(Form form);
        Task DeleteAsync(Form form);
    }
}
