using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Infrastructure.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories
{
    internal sealed class PostgresEmployeesRepository(
        DotNetBoilerplateWriteDbContext dbContext
    ) : IEmployeeRepository
    {
        public async Task<Employee> GetByUserIdAsync(Guid userId)
        {
            return await dbContext.Employees
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<Employee> GetByIdAsync(Guid id)
        {
            return await dbContext.Employees
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await dbContext.Employees.ToListAsync();
        }

        public async Task AddAsync(Employee employee)
        {
            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            dbContext.Employees.Update(employee);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Employee employee)
        {
            dbContext.Employees.Remove(employee);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsByUserIdAsync(Guid userId)
        {
            return await dbContext.Employees
                .AnyAsync(x => x.UserId == userId);
        }

        public async Task<List<Employee>> BrowseByOrganizationId(Guid organizationId)
        {
            return await dbContext.Employees
                .Where(x => x.OrganizationId == organizationId)
                .ToListAsync();
        }
    }
}
