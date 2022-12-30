using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Application.CQRS.User.Commands.CreateUser
{
    public class CreateUserCommandResponse
    {
       public string Id { get; set; }

       public string UserName { get; set; }

    }
}
