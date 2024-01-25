
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.User.Queries.GetUserById
{
  public class GetUserByIdQuery : IGetUserByIdQuery
  {
    private readonly IDatabaseService _databaseService;
    private readonly IMapper _mapper;

    public GetUserByIdQuery(IDatabaseService databaseService, IMapper mapper)
    {
      _databaseService = databaseService;
      _mapper = mapper;
    }

    public async Task<GetUserByIdModel> Execute(int userId)
    {
      var entity = await _databaseService
        .User
        .FirstOrDefaultAsync(x => x.UserId == userId);

      return _mapper.Map<GetUserByIdModel>(entity);
    }
  }
}
