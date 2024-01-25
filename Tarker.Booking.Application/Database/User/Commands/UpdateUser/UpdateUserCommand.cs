using AutoMapper;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.Database.User.Commands.UpdateUser
{
  public class UpdateUserCommand : IUpdateUserCommand
  {
    private readonly IDatabaseService _databaseService;
    private readonly IMapper _mapper;

    public UpdateUserCommand(IDatabaseService databaseService, IMapper mapper)
    {
      _databaseService = databaseService;
      _mapper = mapper;
    }

    public async Task<UpdateUserModel> Execute(UpdateUserModel model)
    {
      var entity = _mapper.Map<UserEntity>(model);
      _databaseService.User.Update(entity);
      await _databaseService.SaveAsync();
      return model;
    }
  }
}
