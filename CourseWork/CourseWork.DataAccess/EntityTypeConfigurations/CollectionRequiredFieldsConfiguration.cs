using CourseWork.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseWork.DataAccess.EntityTypeConfigurations
{
    public class CollectionRequiredFieldsConfiguration
        : IEntityTypeConfiguration<CollectionRequiredFields>
    {
        public void Configure(EntityTypeBuilder<CollectionRequiredFields> builder)
        {
            builder.ToTable(nameof(CollectionRequiredFields)).HasKey(item => item.Id);
            builder.HasIndex(item => item.Id).IsUnique();
            builder.Property(item => item.CollectionId).IsRequired();

            builder.Property(item => item.Boolean1FieldRequired).IsRequired();
            builder.Property(item => item.Boolean1FieldName).HasMaxLength(100).IsRequired();
            builder.Property(item => item.Boolean2FieldRequired).IsRequired();
            builder.Property(item => item.Boolean2FieldName).HasMaxLength(100).IsRequired();
            builder.Property(item => item.Boolean3FieldRequired).IsRequired();
            builder.Property(item => item.Boolean3FieldName).HasMaxLength(100).IsRequired();

            builder.Property(item => item.Date1FieldRequired).IsRequired();
            builder.Property(item => item.Date1FieldName).HasMaxLength(100).IsRequired();
            builder.Property(item => item.Date2FieldRequired).IsRequired();
            builder.Property(item => item.Date2FieldName).HasMaxLength(100).IsRequired();
            builder.Property(item => item.Date3FieldRequired).IsRequired();
            builder.Property(item => item.Date3FieldName).HasMaxLength(100).IsRequired();

            builder.Property(item => item.Int1FieldRequired).IsRequired();
            builder.Property(item => item.Int1FieldName).HasMaxLength(100).IsRequired();
            builder.Property(item => item.Int2FieldRequired).IsRequired();
            builder.Property(item => item.Int2FieldName).HasMaxLength(100).IsRequired();
            builder.Property(item => item.Int3FieldRequired).IsRequired();
            builder.Property(item => item.Int3FieldName).HasMaxLength(100).IsRequired();

            builder.Property(item => item.String1FieldRequired).IsRequired();
            builder.Property(item => item.String1FieldName).HasMaxLength(100).IsRequired();
            builder.Property(item => item.String2FieldRequired).IsRequired();
            builder.Property(item => item.String2FieldName).HasMaxLength(100).IsRequired();
            builder.Property(item => item.String3FieldRequired).IsRequired();
            builder.Property(item => item.String3FieldName).HasMaxLength(100).IsRequired();

            builder.Property(item => item.Text1FieldRequired).IsRequired();
            builder.Property(item => item.Text1FieldName).HasMaxLength(100).IsRequired();
            builder.Property(item => item.Text2FieldRequired).IsRequired();
            builder.Property(item => item.Text2FieldName).HasMaxLength(100).IsRequired();
            builder.Property(item => item.Text3FieldRequired).IsRequired();
            builder.Property(item => item.Text3FieldName).HasMaxLength(100).IsRequired();
        }
    }
}
