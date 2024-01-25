using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Domain.Entities.User;
using Tarker.Booking.Domain.Enums;

namespace Tarker.Booking.Domain.Entities.Booking
{
  public class BookingEntity
  {
    public int BookingId { get; set; }
    public string? Code { get; set; }
    public BookingType? Type { get; set; }
    public DateTime RegisterDate { get; set; }
    public int CustomerId { get; set; }
    public int UserId { get; set; }
    public UserEntity? User { get; set; }
    public CustomerEntity? Customer { get; set; }
  }
}
