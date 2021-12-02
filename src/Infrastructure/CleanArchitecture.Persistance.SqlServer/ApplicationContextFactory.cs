namespace CleanArchitecture.Persistance.SqlServer {
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext> {
        public ApplicationContext CreateDbContext(string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer("MES");

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
