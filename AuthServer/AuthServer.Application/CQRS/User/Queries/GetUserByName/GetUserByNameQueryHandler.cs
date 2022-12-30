using AuthServer.Application.CustomResponses;
using AuthServer.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Application.CQRS.User.Queries.GetUserByName
{
    public class GetUserByNameQueryHandler : IRequestHandler<GetUserByNameQuery, CustomResponse<GetUserByNameQueryResponse>>
    {

        private readonly IUserService _userService;

        public GetUserByNameQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CustomResponse<GetUserByNameQueryResponse>> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserByNameAsync(request);
        }
    }
}
