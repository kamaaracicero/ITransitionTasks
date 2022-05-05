using CourseWork.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseWork.DataAccess.EntityTypeConfigurations
{
    internal class CollectionItemConfiguration : IEntityTypeConfiguration<CollectionItem>
    {
        public void Configure(EntityTypeBuilder<CollectionItem> builder)
        {
            builder.ToTable(nameof(CollectionItem)).HasKey(item => item.Id);
            builder.HasIndex(item => item.Id).IsUnique();
            builder.Property(item => item.CollectionId).IsRequired();
            builder.Property(item => item.Name).HasMaxLength(100).IsRequired();
        }
    }
}
