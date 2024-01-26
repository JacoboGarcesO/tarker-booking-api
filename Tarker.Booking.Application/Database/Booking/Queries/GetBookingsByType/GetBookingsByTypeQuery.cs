using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Domain.Enums;

namespace Tarker.Booking.Application.Database.Booking.Queries.GetBookingsByType
{
  public class GetBookingsByTypeQuery : IGetBookingsByTypeQuery
  {
    private readonly IDatabaseService _databaseService;

    public GetBookingsByTypeQuery(IDatabaseService databaseService)
    {
      _databaseService = databaseService;
    }

    public async Task<List<GetBookingsByTypeModel>> Execute(BookingType type)
    {
      var result = await
        (
          from booking in _databaseService.Booking
          join customer in _databaseService.Customer
          on booking.CustomerId equals customer.CustomerId
          where booking.Type == type
          select new GetBookingsByTypeModel
          {
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
