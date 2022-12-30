using AuthServer.Application.CustomResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Application.CQRS.User.Queries.GetUserByName
{
    public class GetUserByNameQuery : IRequest<CustomResponse<GetUserByNameQueryResponse>>
    {
        public string UserName { get; set; }

        public GetUserByNameQuery(string userName)
        {
            UserName = userName;
        }
    }
}
