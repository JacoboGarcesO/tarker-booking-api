namespace Tarker.Booking.Application.Database.Customer.Queries.GetCustomerById
{
  public class GetCustomerByIdModel
  {
    public int CustomerId { get; set; }
    public string? FullName { get; set; }
    public string? DocumentNumber { get; set; }
  }
}
