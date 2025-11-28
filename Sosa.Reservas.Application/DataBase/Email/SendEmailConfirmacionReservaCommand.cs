using Sosa.Reservas.Application.External.SendGridEmail;
using Sosa.Reservas.Domain.Entidades.Cliente;
using Sosa.Reservas.Domain.Entidades.Habitacion;
using Sosa.Reservas.Domain.Entidades.Reserva;
using Sosa.Reservas.Domain.Models.SendGridEmail;

namespace Sosa.Reservas.Application.DataBase.Email
{
    public class SendEmailConfirmacionReservaCommand : ISendEmailConfirmacionReservaCommand
    {

            private readonly ISendGridEmailService _emailService;

            public SendEmailConfirmacionReservaCommand(ISendGridEmailService emailService)
            {
                _emailService = emailService;
            }

            public async Task Execute(ReservaEntity reserva, ClienteEntity cliente, HabitacionEntity habitacion)
            {
                var emailModel = new SendGridEmailRequestModel
                {
                    From = new ContentEmail
                    {
                        Email = "sosa@bookings.com",
                        Name = "Sistema de Reservas"
                    },
                    Subject = "Confirmación de Reserva",
                    Personalizations = new List<Personalization>
            {
                new Personalization
                {
                    To = new List<ContentEmail>
                    {
                        new ContentEmail
                        {
                            Email = cliente.Usuario.Email,
                            Name = cliente.Usuario.Nombre
                        }
                    }
                }
            },
                    Content = new List<ContentBody>
            {
                new ContentBody
                {
                    Type = "text/html",
                    Value = $@"
                        <h2>¡Reserva confirmada!</h2>
                        <p>Hola {cliente.Usuario.Nombre},</p>
                        <p>Tu reserva fue generada con éxito.</p>
                        <p><b>Hotel:</b> {habitacion.Hotel.Nombre}</p>
                        <p><b>Habitación:</b> {habitacion.Numero}</p>
                        <p><b>Check-in:</b> {reserva.CheckIn:dd/MM/yyyy}</p>
                        <p><b>Check-out:</b> {reserva.CheckOut:dd/MM/yyyy}</p>
                        <p><b>Total:</b> ${reserva.PrecioTotal}</p>
                        <br/>
                        <p>¡Gracias por confiar en nosotros!</p>"
                }
            }
                };

                await _emailService.Execute(emailModel);
            }
        
    }
}
