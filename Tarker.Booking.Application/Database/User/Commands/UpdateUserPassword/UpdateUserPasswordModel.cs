namespace Tarker.Booking.Application.Database.User.Commands.UpdateUserPassword
{
  public class UpdateUserPasswordModel
  {
    public int UserId{ get; set; }
    public string? Password { get; set; }
  }
}
