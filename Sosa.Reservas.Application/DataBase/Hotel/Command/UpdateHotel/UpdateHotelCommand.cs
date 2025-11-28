using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sosa.Reservas.Application.DataBase.Hotel.Command.CreateHotel;
using Sosa.Reservas.Application.Features;
using Sosa.Reservas.Domain.Entidades.Hotel;
using Sosa.Reservas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sosa.Reservas.Application.DataBase.Hotel.Command.UpdateHotel
{
    public class UpdateHotelCommand : IUpdateHotelCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateHotelCommand(
            IDataBaseService dataBaseService,
            IMapper mapper
            )
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<BaseResponseModel> Execute(UpdateHotelModel model)
        {

            var hotel = await _dataBaseService.Hoteles.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (hotel == null)
                return ResponseApiService.Response(StatusCodes.Status404NotFound, "Hotel no encontrado");

            try
            {
                _mapper.Map(model, hotel);
                _dataBaseService.Hoteles.Update(hotel);
                await _dataBaseService.SaveAsync();
            }
            catch (System.Exception)
            {
                return ResponseApiService.Response(
                            StatusCodes.Status400BadRequest);
            }

            return ResponseApiService.Response(
                          StatusCodes.Status200OK,
                        "Hotel modificado correctamente");
        }
    }
}
