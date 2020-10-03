using System;
using System.Collections.Generic;
using System.Text;
using AlDarb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlDarb.DataAccess.EFCore.Configuration.System
{
    public class CourseFieldConfig : BaseEntityConfig<CourseField>
    {
        public CourseFieldConfig() : base("CourseFields")
        {
        }

        public override void Configure(EntityTypeBuilder<CourseField> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.IsDeleted).HasDefaultValue(false);

            //builder.HasKey(cf => new { cf.CourseId, cf.FieldId });

            builder
                .HasOne<Course>(cf => cf.Course)
                .WithMany(c => c.CourseFields)
                .HasForeignKey(cf => cf.CourseId);

            builder
                .HasOne<Field>(cf => cf.Field)
                .WithMany(f => f.CourseFields)
                .HasForeignKey(cf => cf.FieldId);

        }
    }
}
