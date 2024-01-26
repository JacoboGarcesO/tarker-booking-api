using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.Booking.Queries.GetAllBookings
{
  public class GetAllBookingsQuery : IGetAllBookingsQuery
  {
    private readonly IDatabaseService _databaseService;

    public GetAllBookingsQuery(IDatabaseService databaseService)
    {
      _databaseService = databaseService;
    }

    public async Task<List<GetAllBookingsModel>> Execute()
    {
      var result = await 
        (
          from booking in _databaseService.Booking
          join customer in _databaseService.Customer
          on booking.CustomerId equals customer.CustomerId
          select new GetAllBookingsModel
          {
            BookingId = booking.BookingId,
            Code = booking.Code,
            CustomerDocumentNumber = customer.DocumentNumber,
            CustomerFullName = customer.FullName,
            RegisterDate = booking.RegisterDate,
            Type = booking.Type,
          }
        ).ToListAsync();

      return result;
    }
  }
}
