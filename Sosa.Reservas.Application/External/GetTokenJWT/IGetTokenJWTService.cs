using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.External.GetTokenJWT
{
    public interface IGetTokenJWTService
    {
        public string Execute(string id);
    }
}
