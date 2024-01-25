namespace Tarker.Booking.Application.Database.User.Commands.DeleteUser
{
  public interface IDeleteUserCommand
  {
    Task<bool> Execute(int userId);
  }
}
