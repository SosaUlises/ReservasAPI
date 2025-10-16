namespace Sosa.Reservas.Application.DataBase.Login.Queries
{
    public interface ILoginQuery
    {
        Task<string> Execute(LoginModel model);
    }
}
