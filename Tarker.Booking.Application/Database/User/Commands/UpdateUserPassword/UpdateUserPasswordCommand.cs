using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.User.Commands.UpdateUserPassword
{
  public class UpdateUserPasswordCommand : IUpdateUserPasswordCommand
  {
    private readonly IDatabaseService _databaseService;

    public UpdateUserPasswordCommand(IDatabaseService databaseService)
    {
      _databaseService = databaseService;
    }

    public async Task<bool> Execute(UpdateUserPasswordModel model)
    {
      var entity = await _databaseService
        .User
        .FirstOrDefaultAsync(user => user.UserId == model.UserId);

      if (entity == null) return false;

      entity.Password = model.Password;
      return await _databaseService.SaveAsync();
    }
  }
}
