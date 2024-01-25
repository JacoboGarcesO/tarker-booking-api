using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.User.Queries.GetUserByUserNameAndPassword
{
  public class GetUserByUserNameAndPasswordQuery : IGetUserByUserNameAndPasswordQuery
  {

    private readonly IDatabaseService _databaseService;
    private readonly IMapper _mapper;

    public GetUserByUserNameAndPasswordQuery(IDatabaseService databaseService, IMapper mapper)
    {
      _databaseService = databaseService;
      _mapper = mapper;
    }

    public async Task<GetUserByUserNameAndPasswordModel> Execute(string userName, string password)
    {
      var entity = await _databaseService
        .User
        .FirstOrDefaultAsync(x => x.UserName == userName && x.Password == password);

      return _mapper.Map<GetUserByUserNameAndPasswordModel>(entity);
    }
  }
}
