using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Tarker.Booking.Application.Configuration;
using Tarker.Booking.Application.Database.Booking.Commands.CreateBooking;
using Tarker.Booking.Application.Database.Booking.Queries.GetAllBookings;
using Tarker.Booking.Application.Database.Booking.Queries.GetBookingsByDocumentNumber;
using Tarker.Booking.Application.Database.Booking.Queries.GetBookingsByType;
using Tarker.Booking.Application.Database.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.Database.Customer.Commands.DeleteCustomer;
using Tarker.Booking.Application.Database.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.Database.Customer.Queries.GetAllCustomers;
using Tarker.Booking.Application.Database.Customer.Queries.GetCustomerByDocumentNumber;
using Tarker.Booking.Application.Database.Customer.Queries.GetCustomerById;
using Tarker.Booking.Application.Database.User.Commands.CreateUser;
using Tarker.Booking.Application.Database.User.Commands.DeleteUser;
using Tarker.Booking.Application.Database.User.Commands.UpdateUser;
using Tarker.Booking.Application.Database.User.Commands.UpdateUserPassword;
using Tarker.Booking.Application.Database.User.Queries.GetAllUser;
using Tarker.Booking.Application.Database.User.Queries.GetUserById;
using Tarker.Booking.Application.Database.User.Queries.GetUserByUserNameAndPassword;
using Tarker.Booking.Application.Validators.Booking;
using Tarker.Booking.Application.Validators.Customer;
using Tarker.Booking.Application.Validators.User;

namespace Tarker.Booking.Application
{
  public static class DependencyInjectionService
  {
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
      var mapper = new MapperConfiguration(config => config.AddProfile(new MapperProfile()));
      services.AddSingleton(mapper.CreateMapper());

      #region User
      services.AddTransient<ICreateUserCommand, CreateUserCommand>();
      services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
      services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
      services.AddTransient<IUpdateUserPasswordCommand, UpdateUserPasswordCommand>();
      services.AddTransient<IGetAllUserQuery, GetAllUserQuery>();
      services.AddTransient<IGetUserByIdQuery, GetUserByIdQuery>();
      services.AddTransient<IGetUserByUserNameAndPasswordQuery, GetUserByUserNameAndPasswordQuery>();
      #endregion

      #region Customer
      services.AddTransient<ICreateCustomerCommand, CreateCustomerCommand>();
      services.AddTransient<IDeleteCustomerCommand, DeleteCustomerCommand>();
      services.AddTransient<IUpdateCustomerCommand, UpdateCustomerCommand>();
      services.AddTransient<IGetAllCustomersQuery, GetAllCustomersQuery>();
      services.AddTransient<IGetCustomerByIdQuery, GetCustomerByIdQuery>();
      services.AddTransient<IGetCustomerByDocumentNumberQuery, GetCustomerByDocumentNumberQuery>();
      #endregion

      #region Booking
      services.AddTransient<ICreateBookingCommand, CreateBookingCommand>();
      services.AddTransient<IGetAllBookingsQuery, GetAllBookingsQuery>();
      services.AddTransient<IGetBookingByDocumentNumberQuery, GetBookingByDocumentNumberQuery>();
      services.AddTransient<IGetBookingsByTypeQuery, GetBookingsByTypeQuery>();
      #endregion

      #region Validators
      services.AddScoped<IValidator<CreateUserModel>, CreateUserValidator>();
      services.AddScoped<IValidator<UpdateUserModel>, UpdateUserValidator>();
      services.AddScoped<IValidator<UpdateUserPasswordModel>, UpdateUserPasswordValidator>();
      services.AddScoped<IValidator<(string, string)>, GetUserByUserNameAndPasswordValidator>();

      services.AddScoped<IValidator<UpdateCustomerModel>, UpdateCustomerValidator>();
      services.AddScoped<IValidator<CreateCustomerModel>, CreateCustomerValidator>();

      services.AddScoped<IValidator<CreateBookingModel>, CreateBookingValidator>();
      #endregion

      return services;
    }
  }
}
