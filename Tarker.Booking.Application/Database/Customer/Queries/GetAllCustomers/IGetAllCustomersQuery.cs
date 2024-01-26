namespace Tarker.Booking.Application.Database.Customer.Queries.GetAllCustomers
{
  public interface IGetAllCustomersQuery
  {
    Task<List<GetAllCustomersModel>> Execute();
  }
}
