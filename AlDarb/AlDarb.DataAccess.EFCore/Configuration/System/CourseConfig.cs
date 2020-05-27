using System;
using System.Collections.Generic;
using System.Text;
using AlDarb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlDarb.DataAccess.EFCore.Configuration.System
{
    public class CourseConfig : BaseEntityConfig<Course>
    {
        public CourseConfig() : base("Courses")
        {
        }

        public override void Configure(EntityTypeBuilder<Course> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.Name).IsRequired();
            builder.Property(obj => obj.Duration).IsRequired();
            builder.Property(obj => obj.Description).IsRequired();
            builder.Property(obj => obj.IsDeleted).HasDefaultValue(false);

            builder
                .HasOne(obj => obj.User)
                .WithOne()
                .HasForeignKey<User>(obj => obj.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
