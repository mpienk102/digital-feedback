
namespace DotNetBoilerplate.Core.Users;

public interface IUserRepository
{
    Task<User> FindByIdAsync(Guid id);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task<List<User>> GetAllAsync();
}