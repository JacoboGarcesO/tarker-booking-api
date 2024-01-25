using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Persistence.Configuration
{
  public class CustomerConfiguration
  {
    public CustomerConfiguration(EntityTypeBuilder<CustomerEntity> entityBuilder)
    {
      entityBuilder.HasKey(e => e.CustomerId);
      entityBuilder.Property(e => e.FullName).IsRequired();
      entityBuilder.Property(e => e.DocumentNumber).IsRequired();

      entityBuilder
        .HasMany(x => x.Bookings)
        .WithOne(x => x.Customer)
        .HasForeignKey(x => x.CustomerId);
    }
  }
}
