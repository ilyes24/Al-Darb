using AlDarb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.DataAccess.EFCore.Configuration.System
{
    public class CourseSessionConfig : BaseEntityConfig<CourseSession>
    {
        public CourseSessionConfig() : base("CourseSessions")
        {
        }

        public override void Configure(EntityTypeBuilder<CourseSession> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.Capacity).IsRequired();
            builder.Property(obj => obj.StartDate).IsRequired();
            builder.Property(obj => obj.EndDate).IsRequired();
            builder.Property(obj => obj.IsDeleted).HasDefaultValue(false);

            builder.Ignore(x => x.Course);

            builder
                .HasMany(obj => obj.ApplicationForSessions)
                .WithOne()
                .HasForeignKey(obj => obj.CourseSessionId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
