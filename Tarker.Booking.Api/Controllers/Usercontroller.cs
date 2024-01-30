using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.Exceptions;

namespace Tarker.Booking.Api.Controllers
{
  [Route("api/v1/user")]
  [ApiController]
  [TypeFilter(typeof(ExceptionManager))]
  public class Usercontroller : ControllerBase
  {
    public Usercontroller()
    {
    }
  }
}
