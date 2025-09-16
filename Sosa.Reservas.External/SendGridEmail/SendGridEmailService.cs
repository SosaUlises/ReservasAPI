using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using Sosa.Reservas.Application.External.SendGridEmail;
using Sosa.Reservas.Domain.Models.SendGridEmail;
using System.Net.Mail;
using System.Text;

namespace Sosa.Reservas.External.SendGridEmail
{
    public class SendGridEmailService : ISendGridEmailService
    {
        private readonly IConfiguration _configuration;

        public SendGridEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> Execute(SendGridEmailRequestModel model)
        {
            // Obtiene la clave de la API desde la configuración
            string apiKey = _configuration["SendGridEmailKey"];

            // Crea una instancia del cliente de SendGrid
            var client = new SendGridClient(apiKey);

            // Crea un nuevo mensaje de correo
            var msg = new SendGridMessage();
            msg.SetFrom(new EmailAddress(model.From.Email, model.From.Name));
            msg.SetSubject(model.Subject);

            // Agrega los destinatarios
            foreach (var personalization in model.Personalizations)
            {
                var tos = personalization.To.Select(t => new EmailAddress(t.Email, t.Name)).ToList();
                msg.AddTos(tos);
            }

            // Agrega el contenido del correo (HTML o texto plano)
            msg.AddContent(model.Content.First().Type, model.Content.First().Value);

            // Envía el correo
            var response = await client.SendEmailAsync(msg);

            // Verifica si la solicitud fue exitosa
            return response.IsSuccessStatusCode;
        }
    }
}
