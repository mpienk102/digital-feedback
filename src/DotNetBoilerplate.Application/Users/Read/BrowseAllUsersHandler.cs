using DotNetBoilerplate.Shared.Abstractions.Queries;
using DotNetBoilerplate.Core.Users;

namespace DotNetBoilerplate.Application.Users.Read
{
    internal sealed class BrowseUsersHandler(
        IUserRepository userRepository
    ) : IQueryHandler<BrowseUsersQuery, List<UserDto>>
    {
        public async Task<List<UserDto>> HandleAsync(BrowseUsersQuery query)
        {
            var users = await userRepository.GetAllAsync();

            return users.Select(u => new UserDto(
                u.Id,
                u.Email,
                u.Username)).ToList();
        }
    }
    public record UserDto(Guid Id, Email Email, Username Username);
}
