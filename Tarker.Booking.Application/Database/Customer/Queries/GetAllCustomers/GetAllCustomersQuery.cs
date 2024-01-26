using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.Customer.Queries.GetAllCustomers
{
  public class GetAllCustomersQuery : IGetAllCustomersQuery
  {
    private readonly IDatabaseService _databaseService;
    private readonly IMapper _mapper;

    public GetAllCustomersQuery(IDatabaseService databaseService, IMapper mapper)
    {
      _databaseService = databaseService;
      _mapper = mapper;
    }

    public async Task<List<GetAllCustomersModel>> Execute()
    {
      var listEntity = await _databaseService.Customer.ToListAsync();
      return _mapper.Map<List<GetAllCustomersModel>>(listEntity);
    }
  }
}
