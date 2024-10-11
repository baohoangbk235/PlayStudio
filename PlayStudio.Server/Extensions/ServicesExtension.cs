using Microsoft.EntityFrameworkCore;
using PlayStudio.Server.Context;

namespace PlayStudio.Server.Extensions
{
      internal static class ServicesExtension
      {
            internal static WebApplicationBuilder AddServices(this WebApplicationBuilder builder) => builder.AddEntityFramework();
            private static WebApplicationBuilder AddEntityFramework(this WebApplicationBuilder builder)
            {
                  // refactor to services extension
                  var folder = Environment.SpecialFolder.ApplicationData;
                  var path = Environment.GetFolderPath(folder);
                  var DbPath = System.IO.Path.Join(path, "gameclubs.db");
                  if (string.IsNullOrEmpty(DbPath))
                  {
                        throw new Exception("Configuration: [ConnectionStrings.gameclub] is not set");
                  }
                  builder.Services.AddDbContext<PlayStudioContext>((opt) => {
                        opt.UseSqlite($"Data Source={DbPath}");
                  });

                  return builder;
            }
      }


}
