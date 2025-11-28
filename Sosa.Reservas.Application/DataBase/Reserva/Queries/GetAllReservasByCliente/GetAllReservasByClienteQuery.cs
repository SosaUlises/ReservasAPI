using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sosa.Reservas.Application.Features;
using Sosa.Reservas.Domain.Models;
using System.Security.Claims;

namespace Sosa.Reservas.Application.DataBase.Reserva.Queries.GetAllReservasByCliente
{
    public class GetAllReservasByClienteQuery : IGetAllReservasByClienteQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetAllReservasByClienteQuery(
            IDataBaseService dataBaseService,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BaseResponseModel> Execute(int clienteId, int userId)
        {
            var httpUser = _httpContextAccessor.HttpContext.User;

            bool esAdmin = httpUser.IsInRole("Administrador");

            var clienteLog = await _dataBaseService.Clientes
                                   .FirstOrDefaultAsync(c => c.UsuarioId == userId);

            if (clienteLog == null && !esAdmin)
            {
                return ResponseApiService.Response(
                    StatusCodes.Status403Forbidden,
                    "Usuario no válido");
            }

            if (!esAdmin && clienteLog.Id != clienteId)
            {
                return ResponseApiService.Response(
                    StatusCodes.Status403Forbidden,
                    "No puedes acceder a datos de otro usuario");
            }

            var reservas = await _dataBaseService.Reservas
                .Include(r => r.Habitacion)
                .Where(r => r.ClienteId == clienteId)
                .ToListAsync();

            var model = _mapper.Map<List<GetAllReservasByClienteModel>>(reservas);

            return ResponseApiService.Response(
                StatusCodes.Status200OK,
                model
            );
        }

    }
}
