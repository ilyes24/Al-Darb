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
            builder.Property(obj => obj.PictureUrl).HasDefaultValue("https://e-student.org/wp-content/uploads/2019/01/creating-an-online-course-outline-1024x539.png");

            builder.Ignore(x => x.User);

            builder
                .HasMany(obj => obj.CourseSessions)
                .WithOne()
                .HasForeignKey(obj => obj.CourseId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder
                .HasMany(obj => obj.CourseTasks)
                .WithOne()
                .HasForeignKey(obj => obj.CourseId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
