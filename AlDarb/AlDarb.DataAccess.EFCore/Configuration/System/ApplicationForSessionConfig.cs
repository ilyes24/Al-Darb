using AlDarb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.DataAccess.EFCore.Configuration.System
{
    public class ApplicationForSessionConfig : BaseEntityConfig<ApplicationForSession>
    {
        public ApplicationForSessionConfig() : base("ApplicationForSessions")
        {
        }

        public override void Configure(EntityTypeBuilder<ApplicationForSession> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.ApplicationDate).IsRequired();
            builder.Property(obj => obj.Status);
            builder.Property(obj => obj.AcceptedDate);
            builder.Property(obj => obj.IsDeleted).HasDefaultValue(false);

            builder
                .HasOne(obj => obj.User)
                .WithOne()
                .HasForeignKey<User>(obj => obj.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(obj => obj.CourseSession)
                .WithOne()
                .HasForeignKey<CourseSession>(obj => obj.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
