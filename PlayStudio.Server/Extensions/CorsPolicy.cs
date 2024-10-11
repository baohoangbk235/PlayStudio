namespace PlayStudio.Server.Extensions
{
      internal static class CorsExtension
      {
            public static WebApplicationBuilder AddCorsPolicy(this WebApplicationBuilder appBuilder)
            {
                  appBuilder.Services.AddCors(opt =>
                  {
                        opt.AddDefaultPolicy(builder =>
                        {
                              builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials();

                              if (appBuilder.Environment.IsDevelopment())
                              {
                                    builder.SetIsOriginAllowed(origin => true);
                              }
                        });
                  });

                  return appBuilder;
            }
      }
}
