﻿using Company.Business.Domain.Booking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Business.Persistence.Configuration
{
    public class BookingConfiguration
    {
        public BookingConfiguration(EntityTypeBuilder<BookingEntity> entityBuilder)
        {
            entityBuilder.HasKey(x => x.BookingId);
            entityBuilder.Property(x => x.RegistrerDate).IsRequired();
            entityBuilder.Property(x => x.Code).IsRequired();
            entityBuilder.Property(x => x.Type).IsRequired();
            entityBuilder.Property(x => x.UserId).IsRequired();
            entityBuilder.Property(x => x.CustomerId).IsRequired();

            entityBuilder.HasOne(x => x.User)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x=>x.UserId);

            entityBuilder.HasOne(x => x.Customer)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.CustomerId);
        }
    }
}
