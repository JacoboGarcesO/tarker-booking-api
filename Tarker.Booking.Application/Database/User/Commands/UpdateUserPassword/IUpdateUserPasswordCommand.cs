namespace Tarker.Booking.Application.Database.User.Commands.UpdateUserPassword
{
  public interface IUpdateUserPasswordCommand
  {
    Task<bool> Execute(UpdateUserPasswordModel model);
  }
}
