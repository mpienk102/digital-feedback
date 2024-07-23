using DotNetBoilerplate.Core.Employees;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories
{
    internal sealed class InMemoryEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> employees = [];

        public Task<Employee> GetByUserIdAsync(Guid Id)
        {
            var employee = employees.Find(x => x.UserId == Id);

            return Task.FromResult(employee);
        }

        public Task<Employee> GetByIdAsync(Guid id)
        {
            var employee = employees.Find(x => x.EmployeeId == id);

            return Task.FromResult(employee);
        }

        public Task<List<Employee>> GetAllAsync()
        {
            return Task.FromResult(employees);
        }

        public Task AddAsync(Employee employee)
        {
            employees.Add(employee);

            return Task.CompletedTask;
        }

        public Task UpdateAsync(Employee employee)
        {
            var index = employees.FindIndex(x => x.EmployeeId == employee.EmployeeId);
            employees[index] = employee;

            return Task.CompletedTask;
        }

        public Task DeleteAsync(Employee employee)
        {
            employees.Remove(employee);
            return Task.CompletedTask;
        }

        public Task<bool> ExistsByUserIdAsync(Guid userId)
        {
            var exists = employees.Exists(x => x.UserId == userId);
            return Task.FromResult(exists);
        }

        public Task<List<Employee>> BrowseByOrganizationId(Guid organizationId)
        {
            var organizationEmployees = employees.Where(x => x.OrganizationId == organizationId).ToList();
            return Task.FromResult(organizationEmployees);
        }
    }
}