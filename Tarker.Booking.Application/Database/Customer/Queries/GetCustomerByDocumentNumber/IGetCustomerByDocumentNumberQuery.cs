namespace Tarker.Booking.Application.Database.Customer.Queries.GetCustomerByDocumentNumber
{
  public interface IGetCustomerByDocumentNumberQuery
  {
    Task<GetCustomerByDocumentNumberModel> Execute(string documentNumber);
  }
}
