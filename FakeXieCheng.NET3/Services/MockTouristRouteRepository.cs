using FakeXieCheng.NET3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.NET3.Services
{
    /// <summary>
    /// 创建这个MockTouristRouteRepository类就是为了实现刚才创建的ITouristRouteRepository接口,但是这里并没有连接数据库，而是用的内嵌假数据
    /// </summary>
    public class MockTouristRouteRepository : ITouristRouteRepository
    {

        private List<TouristRoute> _routes;
        public MockTouristRouteRepository()//构造函数
        {
            if(_routes == null)
            {
                InitializeTouristRoutes();//为空则初始化创建这个假数据库
            }
        }

        private void InitializeTouristRoutes()
        {
            _routes = new List<TouristRoute>
            {
                new TouristRoute
                {
                    ID = Guid.NewGuid(),
                    Title = "黄山" ,
                    Description = "黄山真好玩",
                    OriginalPrice = 1299,
                    Fetures = "<p>吃住行游购娱</p>",
                    Fees = "<p>交通费自理</p>",
                    Notes = "<p>小心危险</p>"

                },

                new TouristRoute
                {
                    ID = Guid.NewGuid(),
                    Title = "华山" ,
                    Description = "华山 真好玩",
                    OriginalPrice = 1299,
                    Fetures = "<p>吃住行游购娱</p>",
                    Fees = "<p>交通费自理</p>",
                    Notes = "<p>小心危险</p>"

                }

            };
        }
        public IEnumerable<TouristRoute> GetTouristRoutes()
        {
            return _routes; 
        }

        public TouristRoute GetSingleTouristRoute(Guid TouristRouteId)
        {
            //Linq
            return _routes.FirstOrDefault(n => n.ID == TouristRouteId);
        }
    }
}
