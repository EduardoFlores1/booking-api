using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarker.Booking.Domain.Entities.Booking;

namespace Tarker.Booking.Persistence.Configuration
{
    public class BookingConfiguration
    {
        public BookingConfiguration(EntityTypeBuilder<BookingEntity> bookingBuilder)
        {
            bookingBuilder.HasKey(x => x.BookingId);
            bookingBuilder.Property(x => x.RegisterDate).IsRequired();
            bookingBuilder.Property(x => x.Code).IsRequired();
            bookingBuilder.Property(x => x.Type).IsRequired();
            bookingBuilder.Property(x => x.UserId).IsRequired();
            bookingBuilder.Property(x => x.CustomerId).IsRequired();

            bookingBuilder.HasOne(x => x.User)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.UserId);

            bookingBuilder.HasOne(x => x.Customer)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.CustomerId);
        }
    }
}
