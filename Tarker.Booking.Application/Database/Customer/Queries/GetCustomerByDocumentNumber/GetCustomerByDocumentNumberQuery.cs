using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.Customer.Queries.GetCustomerByDocumentNumber
{
  public class GetCustomerByDocumentNumberQuery : IGetCustomerByDocumentNumberQuery
  {
    private readonly IDatabaseService _databaseService;
    private readonly IMapper _mapper;

    public GetCustomerByDocumentNumberQuery(IDatabaseService databaseService, IMapper mapper)
    {
      _databaseService = databaseService;
      _mapper = mapper;
    }

    public async Task<GetCustomerByDocumentNumberModel> Execute(string documentNumber)
    {
      var entity = await _databaseService
        .Customer
        .FirstOrDefaultAsync(customer => customer.DocumentNumber == documentNumber);

      return _mapper.Map<GetCustomerByDocumentNumberModel>(entity);
    }
  }
}
