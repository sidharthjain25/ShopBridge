using DataLayer;
using DataLayer.Entities;
using DataLayer.Implementation;
using DataLayer.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplication1
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
            var connection = Configuration.GetConnectionString("BaseProjectEntities").ToString();
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection), ServiceLifetime.Transient);
            services.AddSwaggerGen(options => options
                .SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "FirstProject Api", Version = "1" }));
            services.AddControllers();
            services.AddTransient<DbContext, DatabaseContext>();
            services.AddTransient<IBaseEntity, BaseEntity>();
            services.AddTransient<IApplicationRepository<User>, ApplicationRepository<User>>();
            services.AddTransient<IApplicationRepository<Inventory>, ApplicationRepository<Inventory>>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(options =>
                options
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseAuthorization();
            app.UseSwagger(null);
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "FirstProject API");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
