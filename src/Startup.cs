using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;


namespace bitly
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
            //Console.WriteLine(Configuration.GetConnectionString("bitly"));
            //["ConnectionStrings:bitly"]
            //Configuration.GetConnectionString("bitly"))
            services.AddDbContext<AppDbContext>(opts =>
                opts.UseNpgsql(Configuration.GetConnectionString("urlShortener")));

            //     services.AddDbContext<BenchmarkContext>(options =>
            // options.UseSqlServer(Configuration.GetConnectionString("TestConnection")));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapControllerRoute("Default", "{controller=default}/{action=Index}/{id?}");
                endpoints.MapControllers();
            });
        }
    }
}
