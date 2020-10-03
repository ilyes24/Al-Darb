using AlDarb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlDarb.DataAccess.EFCore.Configuration.System
{
    class DonationPostConfig : BaseEntityConfig<DonationPost>
    {
        public DonationPostConfig() : base("DonationPosts")
        {
        }

        public override void Configure(EntityTypeBuilder<DonationPost> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.Amount).HasDefaultValue(0);
            builder.Property(obj => obj.Description).IsRequired();
            builder.Property(obj => obj.CreationDate).IsRequired();
            builder.Property(obj => obj.EndDate).IsRequired();

            builder.Ignore(x => x.User);
            builder.Ignore(x => x.Field);
        }
    }
}
