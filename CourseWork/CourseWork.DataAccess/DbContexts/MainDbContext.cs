using CourseWork.Core;
using CourseWork.Core.AdditionalFields;
using CourseWork.Core.UsersActivity;
using CourseWork.DataAccess.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.DataAccess.DbContexts
{
    internal sealed class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        {
        }

        public DbSet<BooleanField> BooleanFields { get; set; }

        public DbSet<DateField> DateFields { get; set; }

        public DbSet<IntField> IntFields { get; set; }

        public DbSet<StringField> StringFields { get; set; }

        public DbSet<TextField> TextFields { get; set; }

        public DbSet<UserComment> UserComments { get; set; }

        public DbSet<UserLike> UserLikes { get; set; }

        public DbSet<Collection> Collections { get; set; }

        public DbSet<CollectionItem> CollectionItems { get; set; }

        public DbSet<CollectionItemTag> CollectionItemTags { get; set; }

        public DbSet<CollectionTheme> CollectionThemes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DateFieldConfiguration());
            builder.ApplyConfiguration(new IntFieldConfiguration());
            builder.ApplyConfiguration(new StringFieldConfiguration());
            builder.ApplyConfiguration(new TextFieldConfiguration());
            builder.ApplyConfiguration(new UserCommentConfiguration());
            builder.ApplyConfiguration(new UserLikeConfiguration());
            builder.ApplyConfiguration(new CollectionConfiguration());
            builder.ApplyConfiguration(new CollectionItemConfiguration());
            builder.ApplyConfiguration(new CollectionItemTagConfiguration());
            builder.ApplyConfiguration(new CollectionThemeConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
