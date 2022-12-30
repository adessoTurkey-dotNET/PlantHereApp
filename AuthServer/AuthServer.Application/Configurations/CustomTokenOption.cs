using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Application.Configurations
{
    public class CustomTokenOption
    {
        public List<String> Audiences { get; set; }

        public string Issuer { get; set; }

        public int AccessTokenExpiration { get; set; }
       
        public int RefreshTokenExpiration { get; set; }

        public string SecurityKey { get; set; }

    }
}
