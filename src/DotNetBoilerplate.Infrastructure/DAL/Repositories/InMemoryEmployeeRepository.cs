using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Projects;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories
{
    internal sealed class InMemoryEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> employees = [];
        public Task AddAsync(Employee employee)
        {
            employees.Add(employee);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Employee employee)
        {
            employees.Remove(employee);
            await Task.CompletedTask;
        }

        public Task<List<Employee>> GetAllAsync()
        {
            return Task.FromResult(employees);
        }

        public Task<Employee> GetByIdAsync(Guid id)
        {
            var employee = employees.Find(x => x.Id == id);

            return Task.FromResult(employee);
        }

        public Task UpdateAsync(Employee employee)
        {
            var index = employees.FindIndex(x => x.Id == employee.Id);
            employees[index] = employee;

            return Task.CompletedTask;
        }
    }
}
