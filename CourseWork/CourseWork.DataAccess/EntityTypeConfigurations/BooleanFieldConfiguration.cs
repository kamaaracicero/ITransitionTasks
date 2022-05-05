using CourseWork.Core.AdditionalFields;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseWork.DataAccess.EntityTypeConfigurations
{
    internal class BooleanFieldConfiguration : IEntityTypeConfiguration<BooleanField>
    {
        public void Configure(EntityTypeBuilder<BooleanField> builder)
        {
            builder.ToTable(nameof(BooleanField)).HasKey(item => item.Id);
            builder.HasIndex(item => item.Id).IsUnique();
            builder.Property(item => item.CollectionItemId).IsRequired();
            builder.Property(item => item.Name).HasMaxLength(100).IsRequired();
            builder.Property(item => item.Value).IsRequired();
        }
    }
}
