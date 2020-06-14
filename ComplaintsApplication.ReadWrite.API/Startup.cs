using System;
using ComplaintsApplication.Infra.IoC;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ComplaintsApplication.ReadWrite.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ServiceProvider { get; internal set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();
            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("https://localhost:44370", "http://localhost:64932")//for origin restriction use .WithOrigin([Origins])
                          .SetIsOriginAllowedToAllowWildcardSubdomains()
                          .AllowCredentials()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
            services.AddMvcCore()
                    .AddApiExplorer()
                    .AddAuthorization();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)//"Bearer"
                   .AddJwtBearer(options =>
                   {
                       // base-address of your identityserver
                       options.Authority = "https://localhost:44325/";// Port 44370;
                       options.RequireHttpsMetadata = false;
                       // name of the API resource
                       options.Audience = "ComplaintsApplicationRead";
                   });//.AddIdentityServerAuthentication(options =>
                   //{
                   //    options.Authority = "http://localhost:44325";
                   //    options.RequireHttpsMetadata = false;
                   //    options.ApiName = "ComplaintsApplicationRead";
                   //});
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Complaints Application Read Write APIs", Version = "v1" });
            });

            services.AddMediatR(typeof(Startup));

            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Complaints Application Microservice V1");
            });

            app.UseRouting();
            app.UseCors("default");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors("default"); ;
            });
        }
    }
}
