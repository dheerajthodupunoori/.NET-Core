using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using SwaggerDemo.Filters;

namespace SwaggerDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, Auth.BasicAuthenticationHandler>("BasicAuthentication", null);
            services.AddScoped<Interface.IUser, Services.UserService>();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                 {
                     builder.AllowCredentials()
                     .AllowAnyHeader().
                     AllowAnyMethod().
                     AllowAnyOrigin();
 
                 });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Swagger Demo", Version = "v1" });

                c.AddSecurityDefinition("Basic", new BasicAuthScheme()
                {
                    Description = "Basic Authentication to user this Service.",
                    Type = "basic"
                });
                c.DocumentFilter<SwaggerSecurityRequirementsDocumentFilter>();
                c.OperationFilter<HeadersFilter>();
            });
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseCors("CorsPolicy");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo");
                c.RoutePrefix = string.Empty;
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }


    public class SwaggerSecurityRequirementsDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Security = new List<IDictionary<string, IEnumerable<string>>>
                {
                new Dictionary<string, IEnumerable<string>>
                {
                    { "Basic", new string[]{ } }
                }
            };
        }

    }

}
