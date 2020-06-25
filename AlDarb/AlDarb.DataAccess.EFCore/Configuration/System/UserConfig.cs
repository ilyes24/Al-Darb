/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using AlDarb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlDarb.DataAccess.EFCore.Configuration.System
{
    public class UserConfig : BaseEntityConfig<User>
    {
        public UserConfig() : base("Users")
        {
        }

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.FirstName);
            builder.Property(obj => obj.LastName);
            builder.Property(obj => obj.Login).IsRequired();
            builder.Property(obj => obj.Password);
            builder.Property(obj => obj.Email).IsRequired();
            builder.Property(obj => obj.Age);
            builder.Property(obj => obj.role).HasDefaultValue("user");
            builder.Property(obj => obj.IsDeleted).HasDefaultValue(false);


            builder.Property(obj => obj.AddressCity).HasColumnName("City");
            builder.Property(obj => obj.AddressStreet).HasColumnName("Street");
            builder.Property(obj => obj.AddressZipCode).HasColumnName("ZipCode");
            builder.Property(obj => obj.AddressLat).HasColumnName("Lat");
            builder.Property(obj => obj.AddressLng).HasColumnName("Lng");

            builder.Property(obj => obj.PhotoUrl);

            builder
                .HasOne(obj => obj.Settings)
                .WithOne(obj => obj.User)
                .HasForeignKey<Settings>(obj => obj.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(obj => obj.UserRoles)
                .WithOne()
                .HasForeignKey(obj => obj.UserId)
                .IsRequired();

            builder
                .HasMany(obj => obj.Claims)
                .WithOne()
                .HasForeignKey(obj => obj.UserId)
                .IsRequired();

            builder
                .HasMany(obj => obj.Courses)
                .WithOne()
                .HasForeignKey(obj => obj.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder
                .HasMany(obj => obj.Notifications)
                .WithOne()
                .HasForeignKey(obj => obj.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder
                .HasMany(obj => obj.ProgressTasks)
                .WithOne()
                .HasForeignKey(obj => obj.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder
                .HasMany(obj => obj.ApplicationForSessions)
                .WithOne()
                .HasForeignKey(obj => obj.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}