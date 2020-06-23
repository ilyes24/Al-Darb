using AlDarb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace AlDarb.DataAccess.EFCore.Configuration.System
{
    public class CourseRatingConfig : BaseEntityConfig<CourseRating>
    {
        public CourseRatingConfig() : base("CourseRatings")
        {
        }

        public override void Configure(EntityTypeBuilder<CourseRating> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.Rating).IsRequired();
            builder.Property(obj => obj.IsDeleted).HasDefaultValue(false);

            builder.Ignore(x => x.User);
            builder.Ignore(x => x.Course);

            builder
                .HasOne<Course>(obj => obj.Course)
                .WithMany()
                .HasForeignKey(obj => obj.CourseId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder
                .HasOne<User>(obj => obj.User)
                .WithMany()
                .HasForeignKey(obj => obj.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
