using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.Database.Booking.Commands.CreateBooking;
using Tarker.Booking.Application.Database.Booking.Queries.GetAllBookings;
using Tarker.Booking.Application.Database.Booking.Queries.GetBookingsByDocumentNumber;
using Tarker.Booking.Application.Database.Booking.Queries.GetBookingsByType;
using Tarker.Booking.Application.Features;
using Tarker.Booking.Domain.Enums;

namespace Tarker.Booking.Api.Controllers
{
  [Route("api/v1/booking")]
  [ApiController]
  public class BookingController : ControllerBase
  {
    [HttpPost("create")]
    public async Task<IActionResult> Create(
      [FromBody] CreateBookingModel model,
      [FromServices] ICreateBookingCommand createBookingCommand,
      [FromServices] IValidator<CreateBookingModel> validator
    )
    {
      var validate = await validator.ValidateAsync(model);

      if (!validate.IsValid)
      {
        return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
      }

      var booking = await createBookingCommand.Execute(model);
      return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, booking));
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll([FromServices] IGetAllBookingsQuery getAllBookingsQuery)
    {
      var bookings = await getAllBookingsQuery.Execute();

      if (bookings == null || bookings.Count == 0)
      {
        return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
      }

      return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, bookings));
    }

    [HttpGet("get-all-by-document/{documentNumber}")]
    public async Task<IActionResult> GetAllByDocumentNumber(
      string documentNumber,
      [FromServices] IGetBookingByDocumentNumberQuery getBookingByDocumentNumberQuery
    )
    {
      var bookings = await getBookingByDocumentNumberQuery.Execute(documentNumber);

      if (bookings == null || bookings.Count == 0)
      {
        return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
      }

      return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, bookings));
    }

    [HttpGet("get-all-by-type/{type}")]
    public async Task<IActionResult> GetAllByType(
      BookingType type,
      [FromServices] IGetBookingsByTypeQuery getBookingsByTypeQuery
    )
    {
      var bookings = await getBookingsByTypeQuery.Execute(type);

      if (bookings == null || bookings.Count == 0)
      {
        return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
      }

      return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, bookings));
    }
  }
}
