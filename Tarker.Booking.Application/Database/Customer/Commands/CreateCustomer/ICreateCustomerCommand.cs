namespace Tarker.Booking.Application.Database.Customer.Commands.CreateCustomer
{
  public interface ICreateCustomerCommand
  {
    Task<CreateCustomerModel> Execute(CreateCustomerModel model);
  }
}
