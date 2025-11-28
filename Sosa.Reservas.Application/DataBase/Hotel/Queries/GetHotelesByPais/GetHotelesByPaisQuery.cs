using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sosa.Reservas.Application.DataBase.Cliente.Queries.GetClienteByDni;
using Sosa.Reservas.Application.Features;
using Sosa.Reservas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Hotel.Queries.GetHotelesByPais
{
    public class GetHotelesByPaisQuery : IGetHotelesByPaisQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetHotelesByPaisQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<BaseResponseModel> Execute(string pais)
        {
            var hoteles = await _dataBaseService.Hoteles
                                    .Where(x => x.Pais == pais)
                                    .ToListAsync();

            if (!hoteles.Any())
            {
                return ResponseApiService.Response(
                    StatusCodes.Status404NotFound,
                    $"No hay hoteles para el país {pais}");
            }

            var model = _mapper.Map<List<GetHotelesByPaisModel>>(hoteles);

            return ResponseApiService.Response(
                StatusCodes.Status200OK,
                model);
        }
    }
}
