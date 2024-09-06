using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.Database.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.Database.Customer.Commands.DeleteCustomer;
using Tarker.Booking.Application.Database.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.Database.Customer.Queries.GetAllCustomer;
using Tarker.Booking.Application.Database.Customer.Queries.GetCustomerByDocumentNumber;
using Tarker.Booking.Application.Database.Customer.Queries.GetCustomerById;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
    [Route("api/v1/customers")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class CustomerController : ControllerBase
    {
        [HttpGet("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateCustomerModel createCustomerModel,
            [FromServices] ICreateCustomerCommand command
            )
        {
            var data = await command.Execute(createCustomerModel);
            return StatusCode(
                   StatusCodes.Status201Created,
                   ResponseApiService.Response(StatusCodes.Status201Created, data, "Cliente creado exitosamente")
                );
        }

        public async Task<IActionResult> Update(
            [FromBody] UpdateCustomerModel updateCustomerModel,
            [FromServices] IUpdateCustomerCommand command
            ) 
        { 
            var data = await command.Execute(updateCustomerModel);
            return StatusCode(
                    StatusCodes.Status200OK,
                    ResponseApiService.Response(StatusCodes.Status200OK, data , "Cliente actualizado exitosamente")
                );
        }

        [HttpDelete("delete/{customerId}")]
        public async Task<IActionResult> Delete(
            int customerId,
            [FromServices] IDeleteCustomerCommand command
            )
        {
            var data = await command.Execute(customerId);

            if (!data)
                return StatusCode(
                        StatusCodes.Status400BadRequest,
                        ResponseApiService.Response(StatusCodes.Status400BadRequest, data, "Error al eliminar cliente")
                    );
            
            return StatusCode(
                        StatusCodes.Status204NoContent,
                        ResponseApiService.Response(StatusCodes.Status204NoContent, data, "Cliente eliminado exitosamente")
                    );
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllCustomerQuery getAllCustomerQuery
            )
        {
            var data = await getAllCustomerQuery.Execute();

            if (data.Count == 0)
                return StatusCode(
                        StatusCodes.Status204NoContent,
                        ResponseApiService.Response(StatusCodes.Status204NoContent, data, "Sin registros")
                    );

            return StatusCode(
                        StatusCodes.Status200OK,
                        ResponseApiService.Response(StatusCodes.Status200OK, data, "Todos los clientes")
                    );
        }

        [HttpGet("get-by-id/{customerId}")]
        public async Task<IActionResult> GetById(
            int customerId,
            [FromServices] IGetCustomerByIdQuery getCustomerByIdQuery
            )
        {
            var data = await getCustomerByIdQuery.Execute(customerId);

            if (data is null)
                return StatusCode(
                        StatusCodes.Status404NotFound,
                        ResponseApiService.Response(StatusCodes.Status404NotFound, data, "Cliente no encontrado")
                    );

            return StatusCode(
                        StatusCodes.Status200OK,
                        ResponseApiService.Response(StatusCodes.Status200OK, data, "Cliente encontrado exitosamente")
                    );
        }

        [HttpGet("get-by-documentNumber/{documentNumber}")]
        public async Task<IActionResult> GetByDocumentNumber(
            string documentNumber,
            [FromServices] IGetCustomerByDocumentNumberQuery getCustomerByDocumentNumberQuery
            )
        {
            var data = await getCustomerByDocumentNumberQuery.Execute(documentNumber);

            if (data is null)
                return StatusCode(
                        StatusCodes.Status404NotFound,
                        ResponseApiService.Response(StatusCodes.Status404NotFound, data, "Cliente no encontrado")
                    );

            return StatusCode(
                        StatusCodes.Status200OK,
                        ResponseApiService.Response(StatusCodes.Status200OK, data, "Cliente encontrado exitosamente")
                    );
        }
    }
}
