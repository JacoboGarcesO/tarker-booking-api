﻿namespace Tarker.Booking.Application.Database.User.Queries.GetAllUser
{
  public class GetAllUserModel
  {
    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
  }
}
