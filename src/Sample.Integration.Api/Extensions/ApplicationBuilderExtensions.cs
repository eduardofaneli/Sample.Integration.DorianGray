using Microsoft.AspNetCore.Builder;

namespace Sample.Integration.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder ConfigureCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger(opt =>
            {
                opt.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Dorian Gray API V1");
                opt.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}
