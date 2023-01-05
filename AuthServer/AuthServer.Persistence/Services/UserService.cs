using AuthServer.Application.CQRS.User.Commands.CreateUser;
using AuthServer.Application.CQRS.User.Commands.CreateUserRoles;
using AuthServer.Application.CQRS.User.Queries.GetUserByName;
using AuthServer.Application.CustomResponses;
using AuthServer.Application.Interfaces.Services;
using AuthServer.Application.Mapping;
using AuthServer.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AuthServer.Persistence.Services
{
    public class UserService : IUserService
    {

        private readonly UserManager<User> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<CustomResponse<CreateUserCommandResponse>> CreateUserAsync(CreateUserCommand createUserCommand)
        {
            var user = new User
            {
                UserName = createUserCommand.UserName,
                Email = createUserCommand.Email
            };

            var result = await _userManager.CreateAsync(user, createUserCommand.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return CustomResponse<CreateUserCommandResponse>.Fail(new ErrorResponse(errors, true), StatusCodes.Status400BadRequest);
            }
            else
            {
                await CreateUserRoles(new CreateUserRolesCommand(user.Email, new List<string> { "customer" }));
                return CustomResponse<CreateUserCommandResponse>.Success(ObjectMapper.Mapper.Map<CreateUserCommandResponse>(user), StatusCodes.Status200OK);
            }
        }


        public async Task<CustomResponse<CreateUserRolesCommandResponse>> CreateUserRoles(CreateUserRolesCommand createUserCommand)
        {

            var user = await _userManager.FindByEmailAsync(createUserCommand.Email);

            if (user == null) return CustomResponse<CreateUserRolesCommandResponse>.Fail("User not found", StatusCodes.Status404NotFound, true);

            if (createUserCommand.Roles == null) return CustomResponse<CreateUserRolesCommandResponse>.Fail("Roles not found", StatusCodes.Status404NotFound, true);

            foreach (var role in createUserCommand.Roles.Select(x => x.ToLower()))
            {
                if (await _roleManager.FindByNameAsync(role) != null)
                {
                    await _userManager.AddToRoleAsync(user, role.ToLower());
                }
                else
                {
                    return CustomResponse<CreateUserRolesCommandResponse>.Fail($"Role({role}) not found", StatusCodes.Status400BadRequest, true);
                }
            }

            return CustomResponse<CreateUserRolesCommandResponse>.Success(StatusCodes.Status201Created);
        }

        public async Task<CustomResponse<GetUserByNameQueryResponse>> GetUserByNameAsync(GetUserByNameQuery getUserByNameQuery)
        {
            var user = await _userManager.FindByNameAsync(getUserByNameQuery.UserName);

            if (user == null)
            {
                return CustomResponse<GetUserByNameQueryResponse>.Fail("UserName not found", 404, true);
            }

            return CustomResponse<GetUserByNameQueryResponse>.Success(ObjectMapper.Mapper.Map<GetUserByNameQueryResponse>(user), StatusCodes.Status200OK);
        }


    }
}