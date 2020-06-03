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

            builder.Ignore(x => x.CourseTask);
            builder.Ignore(x => x.User);
        }
    }
}
