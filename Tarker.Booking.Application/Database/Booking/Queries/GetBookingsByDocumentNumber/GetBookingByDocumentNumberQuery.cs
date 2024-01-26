using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.Booking.Queries.GetBookingsByDocumentNumber
{
  public class GetBookingByDocumentNumberQuery : IGetBookingByDocumentNumberQuery
  {
    private readonly IDatabaseService _databaseService;

    public GetBookingByDocumentNumberQuery(IDatabaseService databaseService)
    {
      _databaseService = databaseService;
    }

    public async Task<List<GetBookingByDocumentNumberModel>> Execute(string documentNumber)
    {
      var result = await
        (
          from booking in _databaseService.Booking
          join customer in _databaseService.Customer
          on booking.CustomerId equals customer.CustomerId
          where customer.DocumentNumber == documentNumber
          select new GetBookingByDocumentNumberModel
          {
            Code = booking.Code,
            RegisterDate = booking.RegisterDate,
            Type = booking.Type,
          }
        ).ToListAsync();

      return result;
    }
  }
}
