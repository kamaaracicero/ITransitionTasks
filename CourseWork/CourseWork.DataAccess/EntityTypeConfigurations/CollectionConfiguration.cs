using CourseWork.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseWork.DataAccess.EntityTypeConfigurations
{
    internal class CollectionConfiguration : IEntityTypeConfiguration<Collection>
    {
        public void Configure(EntityTypeBuilder<Collection> builder)
        {
            builder.ToTable(nameof(Collection)).HasKey(item => item.Id);
            builder.HasIndex(item => item.Id).IsUnique();
            builder.Property(item => item.UserId).HasMaxLength(450).IsRequired();
            builder.Property(item => item.Title).HasMaxLength(100).IsRequired();
            builder.Property(item => item.Description).HasMaxLength(500).IsRequired();
            builder.Property(item => item.CollectionThemeId).IsRequired();
            builder.Property(item => item.Image).IsRequired();
        }
    }
}
