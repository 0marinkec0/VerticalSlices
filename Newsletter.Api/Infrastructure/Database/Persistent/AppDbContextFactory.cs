using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Newsletter.Api.Infrastructure.Database.Persistent;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer("Server=DESKTOP-4UGJ1EH\\SQLEXPRESS;Database=VerticalSlices;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");
        return new AppDbContext(optionsBuilder.Options);
    }
}
