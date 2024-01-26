using Tarker.Booking.Domain.Enums;

namespace Tarker.Booking.Application.Database.Booking.Queries.GetBookingsByDocumentNumber
{
  public class GetBookingByDocumentNumberModel
  {
    public string? Code { get; set; }
    public BookingType? Type { get; set; }
    public DateTime RegisterDate { get; set; }
  }
}
