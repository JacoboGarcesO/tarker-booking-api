using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.Database.User.Commands.CreateUser;
using Tarker.Booking.Application.Database.User.Commands.DeleteUser;
using Tarker.Booking.Application.Database.User.Commands.UpdateUser;
using Tarker.Booking.Application.Database.User.Commands.UpdateUserPassword;
using Tarker.Booking.Application.Database.User.Queries.GetAllUser;
using Tarker.Booking.Application.Database.User.Queries.GetUserById;
using Tarker.Booking.Application.Database.User.Queries.GetUserByUserNameAndPassword;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
  [Route("api/v1/user")]
  [ApiController]
  [TypeFilter(typeof(ExceptionManager))]
  public class Usercontroller : ControllerBase
  {
    [HttpPost("create")]
    public async Task<IActionResult> Create(
      [FromBody] CreateUserModel model,
      [FromServices] ICreateUserCommand createUserCommand
    )
    {
      var data = await createUserCommand.Execute(model);
      return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(
      [FromBody] UpdateUserModel model,
      [FromServices] IUpdateUserCommand updateUserCommand
    )
    {
      var data = await updateUserCommand.Execute(model);
      return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
    }

    [HttpPut("update-password")]
    public async Task<IActionResult> UpdatePassword(
      [FromBody] UpdateUserPasswordModel model,
      [FromServices] IUpdateUserPasswordCommand updateUserPasswordCommand
    )
    {
      var isUpdated = await updateUserPasswordCommand.Execute(model);

      if (!isUpdated)
      {
        return StatusCode(StatusCodes.  , ResponseApiService.Response(StatusCodes.Status404NotFound));
      }

      return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, isUpdated));
    }

    [HttpDelete("delete/{userId}")]
    public async Task<IActionResult> Delete(
      int userId,
      [FromServices] IDeleteUserCommand deleteUserCommand
    )
    {
      if (userId == 0)
      {
        return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
      }

      var wasDeleted = await deleteUserCommand.Execute(userId);

      if (!wasDeleted)
      {
        return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
      }

      return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, wasDeleted));
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll(
      [FromServices] IGetAllUserQuery getAllUserQuery
    )
    {
      var data = await getAllUserQuery.Execute();

      if (data == null || data.Count ==0)
      {
        return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
      }

      return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
    }

    [HttpGet("get-by-id/{userId}")]
    public async Task<IActionResult> GetById(
      int userId,
      [FromServices] IGetUserByIdQuery getUserByIdQuery
    )
    {
      if (userId == 0)
      {
        return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
      }

      var data = await getUserByIdQuery.Execute(userId);

      if (data == null)
      {
        return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
      }

      return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
    }

    [HttpGet("get-by-username-password/{username}/{password}")]
    public async Task<IActionResult> GetByUserNamePassword(
      string username,
      string password,
      [FromServices] IGetUserByUserNameAndPasswordQuery getUserByUserNameAndPasswordQuery
    )
    {
      var data = await getUserByUserNameAndPasswordQuery.Execute(username, password);

      if (data == null)
      {
        return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
      }

      return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
    }
  }
}
