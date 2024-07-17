using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Users.Read
{
    public record BrowseUsersQuery(string Role = null) : IQuery<List<UserDto>>;
}
