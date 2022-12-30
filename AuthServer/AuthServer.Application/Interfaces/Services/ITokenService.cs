using AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByUser;
using AuthServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace AuthServer.Application.Interfaces.Services
{
    public interface ITokenService
    {
        Task<CreateTokenByUserCommandResponse> CreateToken(User user);
    }
}