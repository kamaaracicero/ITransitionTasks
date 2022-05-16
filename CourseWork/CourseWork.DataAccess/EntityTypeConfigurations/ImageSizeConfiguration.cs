using CourseWork.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseWork.DataAccess.EntityTypeConfigurations
{
    public class ImageSizeConfiguration : IEntityTypeConfiguration<ImageSize>
    {
        public void Configure(EntityTypeBuilder<ImageSize> builder)
        {
            builder.ToTable(nameof(ImageSize)).HasKey(item => item.Id);
            builder.HasIndex(item => item.Id).IsUnique();
            builder.Property(item => item.CollectionId).IsRequired();
            builder.Property(item => item.Height).IsRequired();
            builder.Property(item => item.Width).IsRequired();
        }
    }
}
