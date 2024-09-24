using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Server.EFCore;
using Server.EFCoreContext;
using Server.IEFCoreContext;
using Server.IService;
using Server.Service;

namespace Server.Start
{
    public class Startup
    {
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<IUtils, Utils>();
            services.AddTransient<IConfigSetting.IConfigSet, ConfigSetting.ConfigSet>();
            services.AddTransient<IEFContext, EFContext>();
            services.AddTransient<ILoginService, LoginService>();
            //services.AddTransient<IMenuService, MenuService>();
            //services.AddTransient<IUserService, UserService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
