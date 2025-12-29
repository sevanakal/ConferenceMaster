using ConferenceMaster.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        // Docker'daki PostgreSQL adresin
        optionsBuilder.UseNpgsql("Host=localhost;Database=ConferenceDb;Username=postgres;Password=794613");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}