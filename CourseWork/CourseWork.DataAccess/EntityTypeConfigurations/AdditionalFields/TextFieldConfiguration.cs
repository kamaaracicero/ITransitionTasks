using CourseWork.Core.AdditionalFields;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseWork.DataAccess.EntityTypeConfigurations.AdditionalFields
{
    internal class TextFieldConfiguration : IEntityTypeConfiguration<TextField>
    {
        public void Configure(EntityTypeBuilder<TextField> builder)
        {
            builder.ToTable(nameof(TextField)).HasKey(item => item.Id);
            builder.HasIndex(item => item.Id).IsUnique();
            builder.Property(item => item.CollectionItemId).IsRequired();
            builder.Property(item => item.Name).HasMaxLength(100).IsRequired();
            builder.Property(item => item.Value).IsRequired();
        }
    }
}
