using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeJob.Data;
using TimeJob.Data.Interfaces;
using TimeJob.Data.Repository;

namespace TimeJob
{
    
    public class Startup
    {
        private IConfigurationRoot confstring;
        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnv)
        {
            confstring = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsetings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IAllTaskJob, TaskJobRepository>();//реализация интерфейсов

            services.AddDbContext<AppDbContent>(options => options.UseSqlServer(confstring.GetConnectionString("DefaultConnection")));

            services.AddMvc(options => options.EnableEndpointRouting = false);// add mvc
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();//error list
            app.UseStatusCodePages();//code page
            app.UseStaticFiles();//static files
            app.UseRouting();
            app.UseMvcWithDefaultRoute();

            app.UseRouting();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller = Home}/{ation=index}/{id?}");                
            });

            //using (var scope = app.ApplicationServices.CreateScope())
            //{
            //    AppDbContent content = scope.ServiceProvider.GetRequiredService<AppDbContent>();
            //    DBObjects.Initial(content);
            //}
        }

    }
}
