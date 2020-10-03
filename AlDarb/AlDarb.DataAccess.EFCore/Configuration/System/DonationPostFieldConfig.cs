using AlDarb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.DataAccess.EFCore.Configuration.System
{
    public class DonationPostFieldConfig : BaseEntityConfig<DonationPostField>
    {
        public DonationPostFieldConfig() : base("DonationPostFields")
        {
        }

        public override void Configure(EntityTypeBuilder<DonationPostField> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.IsDeleted).HasDefaultValue(false);

            builder.Ignore(x => x.DonationPost);
            builder.Ignore(x => x.Field);
        }
    }
}
