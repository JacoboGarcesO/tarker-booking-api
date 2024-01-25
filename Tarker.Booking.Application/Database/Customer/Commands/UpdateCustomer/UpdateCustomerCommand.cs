using AutoMapper;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Application.Database.Customer.Commands.UpdateCustomer
{
  public class UpdateCustomerCommand : IUpdateCustomerCommand
  {
    private readonly IDatabaseService _databaseService;
    private readonly IMapper _mapper;

    public UpdateCustomerCommand(IDatabaseService databaseService, IMapper mapper)
    {
      _databaseService = databaseService;
      _mapper = mapper;
    }

    public async Task<UpdateCustomerModel> Execute(UpdateCustomerModel model)
    {
      var entity = _mapper.Map<CustomerEntity>(model);
      _databaseService.Customer.Update(entity);
      await _databaseService.SaveAsync();
      return model;
    }
  }
}
