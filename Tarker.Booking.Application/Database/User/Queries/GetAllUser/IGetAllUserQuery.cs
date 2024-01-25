namespace Tarker.Booking.Application.Database.User.Queries.GetAllUser
{
  public interface IGetAllUserQuery
  {
    Task<List<GetAllUserModel>> Execute();
  }
}
