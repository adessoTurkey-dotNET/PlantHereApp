using AuthServer.Application.CQRS.User.Commands.CreateUser;
using AuthServer.Application.CQRS.User.Commands.CreateUserRoles;
using AuthServer.Application.CQRS.User.Queries.GetUserByName;
using AuthServer.Application.CustomResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<CustomResponse<CreateUserCommandResponse>> CreateUserAsync(CreateUserCommand createUserCommand);

        Task<CustomResponse<GetUserByNameQueryResponse>> GetUserByNameAsync(GetUserByNameQuery getUserByNameQuery);

        Task<CustomResponse<CreateUserRolesCommandResponse>> CreateUserRoles(CreateUserRolesCommand createUserCommand);
    }
}
