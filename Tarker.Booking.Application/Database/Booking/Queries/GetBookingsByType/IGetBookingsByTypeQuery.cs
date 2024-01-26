using Tarker.Booking.Domain.Enums;

namespace Tarker.Booking.Application.Database.Booking.Queries.GetBookingsByType
{
  public interface IGetBookingsByTypeQuery
  {
    Task<List<GetBookingsByTypeModel>> Execute(BookingType type);
  }
}
