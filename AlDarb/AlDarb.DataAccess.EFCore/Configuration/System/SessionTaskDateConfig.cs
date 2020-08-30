using AlDarb.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.DataAccess.EFCore.Configuration.System
{
    public class SessionTaskDateConfig : BaseEntityConfig<SessionTaskDate>
    {
        public SessionTaskDateConfig() : base("SessionTaskDates")
        {
        }

        public override void Configure(EntityTypeBuilder<SessionTaskDate> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.SessionId).IsRequired();
            builder.Property(obj => obj.StartDate).IsRequired();
            builder.Property(obj => obj.EndDate).IsRequired();
            builder.Property(obj => obj.TaskId).IsRequired();

            builder.Ignore(x => x.CourseSession);
            builder.Ignore(x => x.CourseTask);
        }
    }
}
