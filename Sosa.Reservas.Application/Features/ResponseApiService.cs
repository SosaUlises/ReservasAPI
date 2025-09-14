using Sosa.Reservas.Domain.Models;

namespace Sosa.Reservas.Application.Features
{
    public static class ResponseApiService
    {
        public static BaseResponseModel Response(int statusCode, object Data = null, string message = null)
        {
            bool success = false;

            if(statusCode >= 200 && statusCode < 300)
            {
                success = true;
            }

            var result = new BaseResponseModel
            {
                StatusCode = statusCode,
                Data = Data,
                Message = message,
                Success = success
            };

            return result;
        }

    }
}
