using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sosa.Reservas.Application.Features;
using Sosa.Reservas.Domain.Entidades.Usuario;
using Sosa.Reservas.Domain.Models;

namespace Sosa.Reservas.Application.DataBase.Usuario.Queries.GetUsuarioById
{
    public class GetUsuarioByIdQuery : IGetUsuarioByIdQuery
    {
        private readonly UserManager<UsuarioEntity> _userManager;
        private readonly IMapper _mapper;

        public GetUsuarioByIdQuery(UserManager<UsuarioEntity> userManager, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<BaseResponseModel> Execute(int id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return ResponseApiService.Response(StatusCodes.Status404NotFound,
                    "Usuario no encontrado");
            }

            return ResponseApiService.Response(StatusCodes.Status200OK,
                _mapper.Map<GetUsuarioByIdModel>(user));

        }

    }
}
