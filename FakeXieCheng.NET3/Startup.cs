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
            services.AddControllers(setupAction => {          //������仰��MVC�Ŀ�����������ܹ�����Ŀ��ʹ��
                setupAction.ReturnHttpNotAcceptable = true;   //ʹ����ʱ����������JSON XML��������ģʽ��������Ĭ�Ϸ���
                setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()  //��Ӷ�xml��ʽ�����֧��
                );
            }).AddXmlDataContractSerializerFormatters();
            //services.AddTransient<ITouristRouteRepository, MockTouristRouteRepository>();//services�������ܿ����ںܶ�ط����ᱻʹ�ã�����Ҫ������ע������<a,b>a�ǽӿڣ�b��ʵ����
            services.AddTransient<ITouristRouteRepository, TouristRouteRepository>();//services�������ܿ����ںܶ�ط����ᱻʹ�ã�����Ҫ������ע������<a,b>a�ǽӿڣ�b��ʵ����
            //services.AddSingleton
            //services.AddScoped
            services.AddDbContext<AppDbContext>(option =>
            {
                ////����������ݿ�
                //option.UseNpgsql(Configuration["DbContext:ConnectionString"]);


                //���ӱ���VS�Դ����ݿ�
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

            app.UseRouting();//���˳������

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
