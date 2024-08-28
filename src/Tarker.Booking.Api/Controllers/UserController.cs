using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.Database.User.Commands.CreateUser;
using Tarker.Booking.Application.Database.User.Commands.DeleteUser;
using Tarker.Booking.Application.Database.User.Commands.UpdateUser;
using Tarker.Booking.Application.Database.User.Commands.UpdateUserPassword;
using Tarker.Booking.Application.Database.User.Queries.GetAllUser;
using Tarker.Booking.Application.Database.User.Queries.GetUserById;
using Tarker.Booking.Application.Database.User.Queries.GetUserByUsernameAndPassword;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class UserController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateUserModel model, 
            [FromServices] ICreateUserCommand createUserCommand)
        {
            var data = await createUserCommand.Execute(model);
            return StatusCode(
                    StatusCodes.Status201Created,
                    ResponseApiService.Response(StatusCodes.Status201Created, data, "Usuario creado exitosamente")
                );
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateUserModel model,
            [FromServices] IUpdateUserCommand updateUserCommand)
        {
            var data = await updateUserCommand.Execute(model);
            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Usuario actualizado exitosamente"));
        }

        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword(
            [FromBody] UpdateUserPasswordModel model,
            [FromServices] IUpdateUserPasswordCommand updateUserPasswordCommand)
        {
            var data = await updateUserPasswordCommand.Execute(model);
            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data, "Password actualizada exitosamente"));
        }

        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> UpdatePassword(
            int userId,
            [FromServices] IDeleteUserCommand deleteUserCommand)
        {
            var data = await deleteUserCommand.Execute(userId);

            if (!data)
                return StatusCode(
                StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status400BadRequest, data, "Error al eliminar usuario"));
            
            return StatusCode(
            StatusCodes.Status404NotFound,
            ResponseApiService.Response(StatusCodes.Status404NotFound, data, "Usuario eliminado exitosamente"));
           
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllUserQuery getAllUserQuery)
        {
            var data = await getAllUserQuery.Execute();

            if (data == null || data.Count == 0)
                return StatusCode(
                StatusCodes.Status404NotFound,
                ResponseApiService.Response(StatusCodes.Status404NotFound, data, "Sin datos"));

            return StatusCode(
            StatusCodes.Status200OK,
            ResponseApiService.Response(StatusCodes.Status200OK, data, "Todos los usuarios"));

        }

        [HttpGet("get-by-id/{userId}")]
        public async Task<IActionResult> GetUserById(
            int userId,
            [FromServices] IGetUserByIdQuery getUserByIdQuery)
        {
            var data = await getUserByIdQuery.Execute(userId);

            if (data == null)
                return StatusCode(
                StatusCodes.Status404NotFound,
                ResponseApiService.Response(StatusCodes.Status404NotFound, data, "Usuario no encontrado"));

            return StatusCode(
            StatusCodes.Status200OK,
            ResponseApiService.Response(StatusCodes.Status200OK, data, "Usuario encontrado exitosamente"));

        }

        [HttpGet("get-by-username-password/{username}/{password}")]
        public async Task<IActionResult> GetUserByUsernameAndPassword(
            string username, string password,
            [FromServices] IGetUserByUsernameAndPasswordQuery getUserByUsernameAndPasswordQuery)
        {
            var data = await getUserByUsernameAndPasswordQuery.Execute(username, password);

            if (data == null)
                return StatusCode(
                StatusCodes.Status404NotFound,
                ResponseApiService.Response(StatusCodes.Status404NotFound, data, "Usuario no encontrado"));

            return StatusCode(
            StatusCodes.Status200OK,
            ResponseApiService.Response(StatusCodes.Status200OK, data, "Usuario encontrado exitosamente"));

        }

    }
}
