using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PortalGroupProject.CMS.Business.Abstract;
using PortalGroupProject.CMS.Business.Adapters;
using PortalGroupProject.CMS.Business.Concrete;
using PortalGroupProject.CMS.DataAccess.Abstract;
using PortalGroupProject.CMS.DataAccess.Concrete;
using PortalGroupProject.CMS.DataAccess.Concrete.EntityFramework;

namespace PortalGroupProject.CMS
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
            services.AddDbContext<PortalDbContext>();
            services.AddControllersWithViews();
            services.AddScoped<IPortalCustomerService, PortalCustomerManager>();
            services.AddScoped<ICustomerCheckService, CustomerCheckManager>();
            services.AddScoped<ICustomerDal, EfCustomerDal>();
            services.AddScoped<IStarbucksCustomerService, StarbucksCustomerManager>();
            services.AddScoped<IStarbucksCustomerDal, EfStarbucksCustomerDal>();
            services.AddScoped<IPortalCustomerDal, EfPortalCustomerDal>();
            services.AddScoped<ICustomerCheckService, MernisServiceAdapter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
