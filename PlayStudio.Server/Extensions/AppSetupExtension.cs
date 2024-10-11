namespace PlayStudio.Server.Extensions
{
      public static class AppSetupExtension
      {
            public static WebApplication SetupApp(this WebApplication app)
            {
                  app.UseCors(option => option.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod());

                  app.UseDefaultFiles();
                  app.UseStaticFiles();

                  // Configure the HTTP request pipeline.
                  if (app.Environment.IsDevelopment())
                  {
                        app.UseSwagger();
                        app.UseSwaggerUI();
                  }

                  app.UseHttpsRedirection();

                  app.UseAuthorization();

                  app.MapControllers();

                  app.MapFallbackToFile("/index.html");


                  return app;
            }
      }
}
