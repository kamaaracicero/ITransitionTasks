using CourseWork.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseWork.DataAccess.EntityTypeConfigurations
{
    internal class CollectionItemTagConfiguration : IEntityTypeConfiguration<CollectionItemTag>
    {
        public void Configure(EntityTypeBuilder<CollectionItemTag> builder)
        {
            builder.ToTable(nameof(CollectionItemTag)).HasKey(item => item.Id);
            builder.HasIndex(item => item.Id).IsUnique();
            builder.Property(item => item.CollectionItemId).IsRequired();
            builder.Property(item => item.Name).HasMaxLength(100).IsRequired();
        }
    }
}
