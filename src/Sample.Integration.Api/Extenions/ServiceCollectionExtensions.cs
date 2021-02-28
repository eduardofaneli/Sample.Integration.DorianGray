using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Sample.Integration.Api.Extenions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Dorian Gray API",
                    Version = "v1",
                    Description = ".NetCore Sample API",
                    Contact = new OpenApiContact
                    {
                        Name = "Eduardo Faneli",
                        Email = "eduardofaneli2@gmail.com",
                        Url = new Uri("https://github.com/eduardofaneli"),
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);                
                opt.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}
