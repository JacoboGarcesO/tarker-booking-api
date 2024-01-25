namespace Tarker.Booking.Application.Database.User.Queries.GetUserByUserNameAndPassword
{
  public interface IGetUserByUserNameAndPasswordQuery
  {
    Task<GetUserByUserNameAndPasswordModel> Execute(string userName, string password);
  }
}
