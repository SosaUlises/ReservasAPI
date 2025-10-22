namespace Sosa.Reservas.Application.External.GetTokenJWT
{
    public interface IGetTokenJWTService
    {
        public string Execute(string id, string role);
    }
}
