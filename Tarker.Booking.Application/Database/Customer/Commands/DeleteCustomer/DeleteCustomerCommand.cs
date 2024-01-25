using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.Customer.Commands.DeleteCustomer
{
  public class DeleteCustomerCommand : IDeleteCustomerCommand
  {
    private readonly IDatabaseService _databaseService;

    public DeleteCustomerCommand(IDatabaseService databaseService)
    {
      _databaseService = databaseService;
    }

    public async Task<bool> Execute(int customerId)
    {
      var entity = await _databaseService.Customer.FirstOrDefaultAsync(customer => customer.CustomerId == customerId);

      if (entity == null) return false;

      _databaseService.Customer.Remove(entity);
      return await _databaseService.SaveAsync();
    }
  }
}
