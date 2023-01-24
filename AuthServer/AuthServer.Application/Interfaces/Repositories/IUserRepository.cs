using AuthServer.Application.CQRS.User.Commands.CreateUser;
using AuthServer.Application.CQRS.User.Commands.CreateUserRoles;
using AuthServer.Application.CQRS.User.Queries.GetUserByName;
using AuthServer.Domain.Entities;

namespace AuthServer.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(CreateUserCommand createUserCommand);

        Task<User> GetUserByNameAsync(GetUserByNameQuery getUserByNameQuery);

        Task<bool> CreateUserRoles(CreateUserRolesCommand createUserCommand);
    }
}
