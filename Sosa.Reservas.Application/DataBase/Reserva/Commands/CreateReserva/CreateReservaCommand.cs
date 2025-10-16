using AutoMapper;
using Sosa.Reservas.Domain.Entidades.Reserva;


namespace Sosa.Reservas.Application.DataBase.Reserva.Commands.CreateReserva
{
    public class CreateReservaCommand : ICreateReservaCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateReservaCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<CreateReservaModel> Execute(CreateReservaModel model)
        {
            var entity = _mapper.Map<ReservaEntity>(model);
            entity.RegistrarFecha = DateTime.UtcNow;
            await _dataBaseService.Reservas.AddAsync(entity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
