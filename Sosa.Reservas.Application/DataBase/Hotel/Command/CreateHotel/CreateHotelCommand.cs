using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Sosa.Reservas.Application.Features;
using Sosa.Reservas.Domain.Entidades.Cliente;
using Sosa.Reservas.Domain.Entidades.Hotel;
using Sosa.Reservas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Hotel.Command.CreateHotel
{
    public class CreateHotelCommand : ICreateHotelCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateHotelCommand(
            IDataBaseService dataBaseService,
            IMapper mapper
            )
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<BaseResponseModel> Execute(CreateHotelModel model)
        {
            var hotel = _mapper.Map<HotelEntity>(model);

            try
            {
                await _dataBaseService.Hoteles.AddAsync(hotel);
                await _dataBaseService.SaveAsync();
            }
            catch (System.Exception)
            {
                return ResponseApiService.Response(
                            StatusCodes.Status400BadRequest);
            }

            return ResponseApiService.Response(
                          StatusCodes.Status201Created,
                        "Hotel creado correctamente");
        }
    }
}
