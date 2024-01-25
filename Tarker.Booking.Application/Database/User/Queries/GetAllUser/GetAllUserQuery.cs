using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.User.Queries.GetAllUser
{
  public class GetAllUserQuery : IGetAllUserQuery
  {
    private readonly IDatabaseService _databaseService;
    private readonly IMapper _mapper;

    public GetAllUserQuery(IDatabaseService databaseService, IMapper mapper)
    {
      _databaseService = databaseService;
      _mapper = mapper;
    }

    public async Task<List<GetAllUserModel>> Execute()
    {
      var listEntity = await _databaseService.User.ToListAsync();
      return _mapper.Map<List<GetAllUserModel>>(listEntity);
    }
  }
}
