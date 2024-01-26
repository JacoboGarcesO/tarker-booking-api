namespace Tarker.Booking.Application.Database.Booking.Queries.GetBookingsByDocumentNumber
{
  public interface IGetBookingByDocumentNumberQuery
  {
    Task<List<GetBookingByDocumentNumberModel>> Execute(string documentNumber);
  }
}
