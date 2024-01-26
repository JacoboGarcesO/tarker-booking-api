namespace Tarker.Booking.Application.Database.Booking.Commands.CreateBooking
{
  public interface ICreateBookingCommand
  {
    Task<CreateBookingModel> Execute(CreateBookingModel model);
  }
}
