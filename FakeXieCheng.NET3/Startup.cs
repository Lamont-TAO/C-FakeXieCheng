using FakeXieCheng.NET3.DataBase;
using FakeXieCheng.NET3.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace FakeXieCheng.NET3
{
    public class Startup

    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(setupAction => {          //有了这句话，MVC的控制器组件就能够在项目中使用
                setupAction.ReturnHttpNotAcceptable = true;   //使访问时候有限制是JSON XML或者其他模式，而不是默认返回
                setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()  //添加对xml格式的输出支持
                );
            }).AddXmlDataContractSerializerFormatters();
            //services.AddTransient<ITouristRouteRepository, MockTouristRouteRepository>();//services这个服务很可能在很多地方都会被使用，所以要在这里注入依赖<a,b>a是接口，b是实现类
            services.AddTransient<ITouristRouteRepository, TouristRouteRepository>();//services这个服务很可能在很多地方都会被使用，所以要在这里注入依赖<a,b>a是接口，b是实现类
            //services.AddSingleton
            //services.AddScoped
            services.AddDbContext<AppDbContext>(option =>
            {
                ////连接外接数据库
                //option.UseNpgsql(Configuration["DbContext:ConnectionString"]);


                //连接本地VS自带数据库
                option.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FakeXiechengDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");




            });

        }
         
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();//这个顺序不能乱

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello .Net core!");
                //});


                //endpoints.MapGet("/test", async context =>
                //{
                //    await context.Response.WriteAsync("Hello .Net core from test!");
                //});

                endpoints.MapControllers();
            });
        }
    }
}
