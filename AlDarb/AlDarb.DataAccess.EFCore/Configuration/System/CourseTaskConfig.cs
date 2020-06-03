using AlDarb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.DataAccess.EFCore.Configuration.System
{
    public class CourseTaskConfig : BaseEntityConfig<CourseTask>
    {
        public CourseTaskConfig() : base("CourseTasks")
        {
        }

        public override void Configure(EntityTypeBuilder<CourseTask> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.Title).IsRequired();
            builder.Property(obj => obj.Duration).IsRequired();
            builder.Property(obj => obj.Description).IsRequired();
            builder.Property(obj => obj.Difficulty).IsRequired();
            builder.Property(obj => obj.IsDeleted).HasDefaultValue(false);

            builder.Ignore(x => x.Course);

            builder
                .HasMany(obj => obj.ProgressTasks)
                .WithOne()
                .HasForeignKey(obj => obj.CourseTaskId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
