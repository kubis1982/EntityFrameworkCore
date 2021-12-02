namespace CleanArchitecture.Persistance.SqlServer {
    using CleanArchitecture.Persistance.SqlServer.Entities;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationContext : DbContext {
        public ApplicationContext(DbContextOptions<ApplicationContext> dbContextOptions) : base(dbContextOptions) {
        }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
