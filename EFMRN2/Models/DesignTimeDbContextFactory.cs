using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EFMRN2.Models
{
  public class EFMRN2ContextFactory : IDesignTimeDbContextFactory<EFMRN2Context>
  {

    EFMRN2Context IDesignTimeDbContextFactory<EFMRN2Context>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<EFMRN2Context>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new EFMRN2Context(builder.Options);
    }
  }
}