using EF_Core;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class EShopContextFactory : IDesignTimeDbContextFactory<EShopContext>
{
    public EShopContext CreateDbContext(string[] args)
    {
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "EShop.Presentation"); // ده لو appsettings في WebApp

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("MyDB"); // 👍 هنا الصح

        var optionsBuilder = new DbContextOptionsBuilder<EShopContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new EShopContext(optionsBuilder.Options);
    }
}
