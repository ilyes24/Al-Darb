using AlDarb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.DataAccess.EFCore.Configuration.System
{
    public class ProgressTaskConfig : BaseEntityConfig<ProgressTask>
    {
        public ProgressTaskConfig() : base("ProgressTasks")
        {
        }

        public override void Configure(EntityTypeBuilder<ProgressTask> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.progress).IsRequired();
            builder.Property(obj => obj.ProgressDate).IsRequired();
            builder.Property(obj => obj.rating);
            builder.Property(obj => obj.IsDeleted).HasDefaultValue(false);

            builder
                .HasOne(obj => obj.User)
                .WithOne()
                .HasForeignKey<User>(obj => obj.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(obj => obj.CourseTask)
                .WithOne()
                .HasForeignKey<CourseTask>(obj => obj.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
