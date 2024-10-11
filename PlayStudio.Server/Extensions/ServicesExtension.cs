using Microsoft.EntityFrameworkCore;
using PlayStudio.Server.Context;

namespace PlayStudio.Server.Extensions
{
      internal static class ServicesExtension
      {
            internal static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
            {
                  builder.AddEntityFramework();
                  return builder;
            }
            private static WebApplicationBuilder AddEntityFramework(this WebApplicationBuilder builder)
            {
                  string currentDirectory = Directory.GetCurrentDirectory();
                  var DbPath = System.IO.Path.Join(currentDirectory, "gameclubs.db");
                  if (string.IsNullOrEmpty(DbPath))
                  {
                        throw new Exception("Configuration: [ConnectionStrings.gameclub] is not set");
                  }
                  builder.Services.AddDbContext<PlayStudioContext>((opt) =>
                  {
                        opt.UseSqlite($"Data Source={DbPath}");
                  });

                  return builder;
            }
      }
}
