namespace Tarker.Booking.Application.Database.Booking.Queries.GetAllBookings
{
  public interface IGetAllBookingsQuery
  {
    Task<List<GetAllBookingsModel>> Execute();
  }
}
