using CourseWork.Core.UsersActivity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseWork.DataAccess.EntityTypeConfigurations.UsersActivity
{
    internal class UserCommentConfiguration : IEntityTypeConfiguration<UserComment>
    {
        public void Configure(EntityTypeBuilder<UserComment> builder)
        {
            builder.ToTable(nameof(UserComment)).HasKey(item => item.Id);
            builder.HasIndex(item => item.Id).IsUnique();
            builder.Property(item => item.CollectionItemId).IsRequired();
            builder.Property(item => item.UserId).HasMaxLength(450).IsRequired();
            builder.Property(item => item.Text).IsRequired();
            builder.Property(item => item.Date).IsRequired();
        }
    }
}
