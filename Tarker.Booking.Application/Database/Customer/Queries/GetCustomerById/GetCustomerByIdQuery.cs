using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.Customer.Queries.GetCustomerById
{
  public class GetCustomerByIdQuery : IGetCustomerByIdQuery
  {
    private readonly IDatabaseService _databaseService;
    private readonly IMapper _mapper;

    public GetCustomerByIdQuery(IDatabaseService databaseService, IMapper mapper)
    {
      _databaseService = databaseService;
      _mapper = mapper;
    }

    public async Task<GetCustomerByIdModel> Execute(int customerId)
    {
      var entity = await _databaseService
        .Customer
        .FirstOrDefaultAsync(customer => customer.CustomerId == customerId);
      
      return _mapper.Map<GetCustomerByIdModel>(entity);
    }
  }
}
