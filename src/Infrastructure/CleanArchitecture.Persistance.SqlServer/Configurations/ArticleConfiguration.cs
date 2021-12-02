namespace CleanArchitecture.Persistance.SqlServer.Configurations {
    using CleanArchitecture.Persistance.SqlServer.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ArticleConfiguration : IEntityTypeConfiguration<Article> {
        public void Configure(EntityTypeBuilder<Article> builder) {
            builder.ToTable(Schema.Seven, "Article");

            builder.HasKey(e => e.Id);

            builder.Property(n => n.Code)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(n => n.Name)
                .HasMaxLength(255);

            builder.Property(n => n.Unit)
                .HasMaxLength(10);

            var unitsNavigation = builder.OwnsMany(n => n.Units, n => {
                n.ToTable("ArticleUnit", "Seven");
                n.Property(n => n.Unit).HasMaxLength(10);
                n.HasKey(nameof(Article) + nameof(Article.Id), nameof(ArticleUnit.Unit));
            });
        }
    }
}
