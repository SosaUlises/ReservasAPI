using Sosa.Reservas.Domain.Models.SendGridEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.External.SendGridEmail
{
    public interface ISendGridEmailService
    {
        Task<bool> Execute(SendGridEmailRequestModel model);
    }
}
