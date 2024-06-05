using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TomasosPizzeria.Infrastructure.Context;

public class TomasosContextFactory : IDesignTimeDbContextFactory<TomasosContext>
{
    public TomasosContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TomasosContext>();
        optionsBuilder.UseSqlServer("Server=tcp:tomasosgrimlund.database.windows.net,1433;Initial Catalog=TomasosDb;Persist Security Info=False;User ID=adminuser;Password=Tomasos1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        return new TomasosContext(optionsBuilder.Options);
    }
}