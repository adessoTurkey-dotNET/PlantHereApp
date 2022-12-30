using AuthServer.Application.CustomResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Application.CQRS.Authentication.Commands.RevokeRefreshToken
{
    public class RevokeRefreshTokenCommand:IRequest<CustomResponse<RevokeRefreshTokenCommandResponse>>
    {
        public string RefleshToken { get; set; }

     
        public RevokeRefreshTokenCommand(string refleshToken)
        {
            RefleshToken = refleshToken;
        }
    }
}
