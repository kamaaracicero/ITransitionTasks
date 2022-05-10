using CourseWork.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseWork.DataAccess.EntityTypeConfigurations
{
    internal class CollectionThemeConfiguration : IEntityTypeConfiguration<CollectionTheme>
    {
        public void Configure(EntityTypeBuilder<CollectionTheme> builder)
        {
            builder.ToTable(nameof(CollectionTheme)).HasKey(item => item.Id);
            builder.HasIndex(item => item.Id).IsUnique();
            builder.Property(item => item.Theme).HasMaxLength(100).IsRequired();
        }
    }
}
