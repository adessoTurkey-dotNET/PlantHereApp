using AuthServer.Application.CustomResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByRefreshToken
{
    public class CreateTokenByRefreshTokenCommand:IRequest<CustomResponse<CreateTokenByRefreshTokenCommandResponse>>
    {
        public string RefreshToken { get; set; }

    }
}
