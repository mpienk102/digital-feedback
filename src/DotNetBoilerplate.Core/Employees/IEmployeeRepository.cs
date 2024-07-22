namespace DotNetBoilerplate.Core.Employees
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByUserIdAsync(Guid Id);
        Task<Employee?> GetByIdAsync(Guid id);
        Task<List<Employee>> GetAllAsync();
        Task AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(Employee employee);
        Task<bool> ExistsByUserIdAsync(Guid userId);
        Task<List<Employee>> BrowseByOrganizationId(Guid organizationId);
    }
}