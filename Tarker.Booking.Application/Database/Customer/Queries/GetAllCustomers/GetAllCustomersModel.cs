﻿namespace Tarker.Booking.Application.Database.Customer.Queries.GetAllCustomers
{
  public class GetAllCustomersModel
  {
    public int CustomerId { get; set; }
    public string? FullName { get; set; }
    public string? DocumentNumber { get; set; }
  }
}
