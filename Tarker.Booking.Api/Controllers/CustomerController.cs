using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.Database.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.Database.Customer.Commands.DeleteCustomer;
using Tarker.Booking.Application.Database.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.Database.Customer.Queries.GetAllCustomers;
using Tarker.Booking.Application.Database.Customer.Queries.GetCustomerByDocumentNumber;
using Tarker.Booking.Application.Database.Customer.Queries.GetCustomerById;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
  [Route("api/v1/customer")]
  [ApiController]
  public class CustomerController : ControllerBase
  {
    [HttpPost("create")]
    public async Task<IActionResult> Create(
      [FromBody] CreateCustomerModel model,
      [FromServices] ICreateCustomerCommand createCustomerCommand
    )
    {
      var customer = await createCustomerCommand.Execute(model);
      return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, customer));
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(
      [FromBody] UpdateCustomerModel model,
      [FromServices] IUpdateCustomerCommand updateCustomerCommand
    )
    {
      var customer = await updateCustomerCommand.Execute(model);
      return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, customer));
    }

    [HttpDelete("delete/{customerId}")]
    public async Task<IActionResult> Delete(
      int customerId,
      [FromServices] IDeleteCustomerCommand deleteCustomerCommand
    )
    {
      if (customerId == 0)
      {
        return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
      }

      var wasDeleted = await deleteCustomerCommand.Execute(customerId);

      if (!wasDeleted)
      {
        return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
      }

      return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, wasDeleted));
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll([FromServices] IGetAllCustomersQuery getAllCustomersQuery)
    {
      var customers = await getAllCustomersQuery.Execute();

      if (customers == null || customers.Count == 0)
      {
        return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
      }

      return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, customers));
    }

    [HttpGet("get-by-id/{customerId}")]
    public async Task<IActionResult> GetById(int customerId, [FromServices] IGetCustomerByIdQuery getCustomerByIdQuery)
    {
      if (customerId == 0)
      {
        return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
      }

      var customer = await getCustomerByIdQuery.Execute(customerId);

      if (customer == null)
      {
        return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
      }

      return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, customer));
    }

    [HttpGet("get-by-document/{documentNumber}")]
    public async Task<IActionResult> GetByDocumentNumber(string documentNumber, [FromServices] IGetCustomerByDocumentNumberQuery getCustomerByDocumentNumberQuery)
    {
      var customer = await getCustomerByDocumentNumberQuery.Execute(documentNumber);

      if (customer == null)
      {
        return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
      }

      return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, customer));
    }
  }
}
