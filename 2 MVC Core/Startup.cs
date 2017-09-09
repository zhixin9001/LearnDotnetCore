using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using _1_EFCore_1;
using _2_1MVCCoreLib;
using System.Reflection;

namespace _2_MVC_Core {
  public class Startup {
    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {

      services.AddSingleton(typeof(Person));
      services.AddSingleton(typeof(User));
      services.AddSingleton(typeof(ExceptionFilter));
      
      var serviceAsm = Assembly.Load(new AssemblyName("2_1 MVC Core Lib"));
      var serviceTypes = serviceAsm.GetTypes().Where(t => typeof(IServiceTag)
       .IsAssignableFrom(t) && !t.GetTypeInfo().IsAbstract);
      foreach (var serviceType in serviceTypes) {
        var interfaceTypes = serviceType.GetInterfaces().Where(t => t.Name != "IServiceTag");
        foreach (var interfaceType in interfaceTypes) {
          services.AddSingleton(interfaceType, serviceType);
        }
      }

      services.AddMvc(options => {
        var serviceProvider = services.BuildServiceProvider();
        var filter = serviceProvider.GetService<ExceptionFilter>();
        options.Filters.Add(filter);
      });

      //services.AddSession();
      //services.AddMemoryCache();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
        app.UseBrowserLink();
      }
      else {
        app.UseExceptionHandler("/Home/Error");
      }

      app.UseStaticFiles();
      
      app.UseMvc(routes => {
        routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
