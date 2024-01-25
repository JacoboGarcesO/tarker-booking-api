namespace Tarker.Booking.Application.Database.Customer.Commands.DeleteCustomer
{
  public interface IDeleteCustomerCommand
  {
    Task<bool> Execute(int customerId);
  }
}
