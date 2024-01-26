using Tarker.Booking.Domain.Enums;

namespace Tarker.Booking.Application.Database.Booking.Queries.GetBookingsByType
{
  public class GetBookingsByTypeModel
  {
    public string? Code { get; set; }
    public BookingType? Type { get; set; }
    public DateTime RegisterDate { get; set; }
    public string? CustomerFullName { get; set; }
    public string? CustomerDocumentNumber { get; set; }
  }
}
