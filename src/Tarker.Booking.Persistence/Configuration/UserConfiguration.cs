using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Persistence.Configuration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<UserEntity> userBuilder)
        {
            userBuilder.HasKey(x => x.UserId);
            userBuilder.Property(x => x.FirstName).IsRequired();
            userBuilder.Property(x => x.LastName).IsRequired();
            userBuilder.Property(x => x.Username).IsRequired();
            userBuilder.Property(x => x.Password).IsRequired();

            userBuilder.HasMany(x => x.Bookings)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}
