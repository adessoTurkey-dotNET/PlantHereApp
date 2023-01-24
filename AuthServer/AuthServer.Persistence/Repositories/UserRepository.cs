using AuthServer.Application.CQRS.User.Commands.CreateUser;
using AuthServer.Application.CQRS.User.Commands.CreateUserRoles;
using AuthServer.Application.CQRS.User.Queries.GetUserByName;
using AuthServer.Application.Exceptions;
using AuthServer.Application.Interfaces.Repositories;
using AuthServer.Domain.Entities;
using Microsoft.AspNetCore.Identity;


namespace AuthServer.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly UserManager<User> _userManager;


        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<User> CreateUserAsync(CreateUserCommand createUserCommand)
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

                throw new ClientSideException(errors.FirstOrDefault());
            }
            else
            {
                await CreateUserRoles(new CreateUserRolesCommand(user.Email, new List<string> { "customer" }));
                return user;
            }
        }

        public async Task<User> GetUserByNameAsync(GetUserByNameQuery getUserByNameQuery)
        {
            var user = await _userManager.FindByNameAsync(getUserByNameQuery.UserName);

            if (user == null)
            {
                throw new NotFoundException("User Not Found");
            }

            return user;
        }

        public async Task<bool> CreateUserRoles(CreateUserRolesCommand createUserCommand)
        {

            var user = await _userManager.FindByEmailAsync(createUserCommand.Email);

            if (user == null) throw new NotFoundException("User Not Found");

            if (createUserCommand.Roles == null) throw new NotFoundException("Roles Not Found");

            foreach (var role in createUserCommand.Roles.Select(x => x.ToLower()))
            {
                if (await _roleManager.FindByNameAsync(role) != null)
                {
                    await _userManager.AddToRoleAsync(user, role.ToLower());
                }
                else
                {
                    throw new NotFoundException($"Role({role}) not found");
                }
            }

            return true;
        }
    }
}