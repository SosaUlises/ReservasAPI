using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sosa.Reservas.Application.Features;
using Sosa.Reservas.Domain.Models;

namespace Sosa.Reservas.Application.DataBase.Cliente.Queries.GetClienteByDni
{
    public class GetClienteByDniQuery : IGetClienteByDniQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetClienteByDniQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<BaseResponseModel> Execute(string dni)
        {
            var cliente = await _dataBaseService.Clientes
                                          .Include(x => x.Usuario)
                                          .FirstOrDefaultAsync(x => x.Usuario.Dni == dni);

            if (cliente == null)
            {
                return ResponseApiService.Response(StatusCodes.Status404NotFound,
                    "Cliente no encontrado");
            }

            return ResponseApiService.Response(StatusCodes.Status200OK,
                    _mapper.Map<GetClienteByDniModel>(cliente));
        }
    }
}
