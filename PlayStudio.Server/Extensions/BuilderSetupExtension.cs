namespace PlayStudio.Server.Extensions
{
      public static class BuilderSetupExtension
      {
            public static WebApplicationBuilder SetupBuilder(this WebApplicationBuilder builder)
            {
                  builder.Services.AddControllers();
                  builder.Services.AddEndpointsApiExplorer();
                  builder.Services.AddSwaggerGen();

                  builder
                      .AddServices()
                      .AddCorsPolicy();
                  return builder;
            }
      }
}
