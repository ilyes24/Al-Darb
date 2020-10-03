using AlDarb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlDarb.DataAccess.EFCore.Configuration.System
{
    class DonationConfig : BaseEntityConfig<Donation>
    {
        public DonationConfig() : base("Donations")
        {
        }

        public override void Configure(EntityTypeBuilder<Donation> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.DonationAmount).HasDefaultValue(0);

            builder.Ignore(x => x.User);
            builder.Ignore(x => x.DonationPost);
        }
    }
}
