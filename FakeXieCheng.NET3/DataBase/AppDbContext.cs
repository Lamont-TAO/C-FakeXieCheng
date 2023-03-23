using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeXieCheng.NET3.Models;
using Microsoft.EntityFrameworkCore;//引入entity framework core
using System.IO;//为了引入json文件
using System.Reflection;//读入文件需要知道文件路径，就需要这个反射工具
using Newtonsoft.Json;//这个工具包是专门处理Json数据的

namespace FakeXieCheng.NET3.DataBase
{
    public class AppDbContext : DbContext
    {
        //创建实例对象，通过传参实现
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //建立旅游路线和路线图片两个方面的映射
        public DbSet<TouristRoute> TouristRoutes { get; set; }
        public DbSet<TouristRoutePicture> TouristRoutePictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////制作种子数据
            //modelBuilder.Entity<TouristRoute>().HasData(new TouristRoute()
            //{
            //    ID = Guid.NewGuid(),
            //    Title = "ceshititle",
            //    Description = "shuoming",
            //    OriginalPrice = 0,
            //    CreateTime = DateTime.UtcNow
            //});


            //读路线数据
            var touristRouteJsonData = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"/DataBase/touristRouteMockData.json");
            IList<TouristRoute> touristRoutes = JsonConvert.DeserializeObject<IList<TouristRoute>>(touristRouteJsonData);
            modelBuilder.Entity<TouristRoute>().HasData(touristRoutes);
            base.OnModelCreating(modelBuilder);
            //读路线图片数据
            var touristRoutePictureJsonData = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"/DataBase/touristRoutePicturesMockData.json");
            IList<TouristRoutePicture> touristRoutePictures = JsonConvert.DeserializeObject<IList<TouristRoutePicture>>(touristRoutePictureJsonData);
            modelBuilder.Entity<TouristRoutePicture>().HasData(touristRoutePictures);
            base.OnModelCreating(modelBuilder);
        }
    }
}
