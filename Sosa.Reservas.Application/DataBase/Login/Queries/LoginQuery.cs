using Sosa.Reservas.Application.External.GetTokenJWT;

namespace Sosa.Reservas.Application.DataBase.Login.Queries
{
    public class LoginQuery : ILoginQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IGetTokenJWTService _getTokenJWTService;

        public LoginQuery(
            IDataBaseService dataBaseService,
            IGetTokenJWTService getTokenJWTService)
        {
            _dataBaseService = dataBaseService;
            _getTokenJWTService = getTokenJWTService;

        }

        public async Task<string> Execute(LoginModel model)
        {
            var user = _dataBaseService.Usuarios.FirstOrDefault(u => u.UserName == model.UserName);

            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password)) // Validamos
            {
                return null;
            }

            var token = _getTokenJWTService.Execute(user.UserId.ToString());

            return token;
        }
    }
}
