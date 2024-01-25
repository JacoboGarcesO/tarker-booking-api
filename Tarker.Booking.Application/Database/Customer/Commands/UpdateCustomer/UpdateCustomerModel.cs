namespace Tarker.Booking.Application.Database.Customer.Commands.UpdateCustomer
{
  public class UpdateCustomerModel
  {
    public int CustomerId { get; set; }
    public string? FullName { get; set; }
    public string? DocumentNumber { get; set; }
  }
}
