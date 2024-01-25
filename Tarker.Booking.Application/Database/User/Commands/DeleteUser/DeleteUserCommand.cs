using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.User.Commands.DeleteUser
{
  public class DeleteUserCommand : IDeleteUserCommand
  {
    private readonly IDatabaseService _databaseService;

    public DeleteUserCommand(IDatabaseService databaseService, IMapper mapper)
    {
      _databaseService = databaseService;
    }

    public async Task<bool> Execute(int userId)
    {
      var entity = await _databaseService.User.FirstOrDefaultAsync(user => user.UserId == userId);
      if (entity == null) return false;

      _databaseService.User.Remove(entity);
      return await _databaseService.SaveAsync();
    }
  }
}
