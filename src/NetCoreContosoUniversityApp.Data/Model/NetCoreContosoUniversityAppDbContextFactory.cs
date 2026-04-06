using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NetCoreContosoUniversityApp.Data.Model
{
    /// <summary>
    /// Factory class used by Entity Framework Core at design time to create an instance 
    /// of <see cref="NetCoreContosoUniversityAppDbContext"/>.
    /// </summary>
    /// <remarks>
    /// This class is typically used for design-time operations such as running EF Core migrations.
    /// </remarks>
    public class NetCoreContosoUniversityAppDbContextFactory : IDesignTimeDbContextFactory<NetCoreContosoUniversityAppDbContext>
    {
        /// <summary>
        /// Creates a new instance of <see cref="NetCoreContosoUniversityAppDbContext"/> with configuration 
        /// loaded from the API project's appsettings.json file.
        /// </summary>
        /// <param name="args">Command-line arguments (not used in this implementation).</param>
        /// <returns>A configured <see cref="NetCoreContosoUniversityAppDbContext"/> instance.</returns>
        public NetCoreContosoUniversityAppDbContext CreateDbContext(string[] args)
        {
            // Build the configuration by locating the appsettings.json file
            // in the API project directory (1 directory level up from the current directory).
            // Go from /bin/Debug/netX.0/ back to the solution folder and into the API project
            var basePath = Path.GetFullPath(
                Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "NetCoreContosoUniversityApp.Web.API")
            );

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            // Create the DbContext options builder
            var optionsBuilder = new DbContextOptionsBuilder<NetCoreContosoUniversityAppDbContext>();

            // Configure the DbContext to use SQL Server with the "NetCoreContosoUniversityAppConnection" connection string
            optionsBuilder
                .UseSqlServer(configuration.GetConnectionString("NetCoreContosoUniversityAppConnection"));

            // Return a new instance of the context with the configured options
            return new NetCoreContosoUniversityAppDbContext(optionsBuilder.Options);
        }
    }
}
