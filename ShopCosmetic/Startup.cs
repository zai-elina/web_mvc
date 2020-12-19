using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopCosmetic.Data;
using ShopCosmetic.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using ShopCosmetic.Data.Repository;
using Microsoft.AspNetCore.Http;
using ShopCosmetic.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ShopCosmetic
{
    public class Startup
    {
        private IConfigurationRoot _confstring;
        public Startup(IWebHostEnvironment hostEnv)
        {
            _confstring = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
       
        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(_confstring.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();
            services.AddTransient<ICosmetic, CosmeticRepository>();
            services.AddTransient<ICosmeticCategory, CategoryRepository>();
            services.AddTransient<IAllOrders,OrdersRepository>();
            services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();//позволяет работать с сессиями
            services.AddScoped(p=>ShoppingCart.GetCart(p));//позволяет выводить разные корзины для разных пользователей
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDBContext>();

            services.AddMvc();
            services.AddMemoryCache();//используем кэш
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            //app.UseStatusCodePages();
         
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
           
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "categoryFiltter",
                    pattern: "Cosmetic/{action}/{category?}",
                    defaults: new { Controller = "Cosmetic", action = "List"});

            });
            
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContext context = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                DBInitializer.Start(context);
            }

        }
    }
}
