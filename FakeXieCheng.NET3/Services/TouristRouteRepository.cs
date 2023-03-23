using FakeXieCheng.NET3.DataBase;
using FakeXieCheng.NET3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.NET3.Services
{
    public class TouristRouteRepository : ITouristRouteRepository
    {
        private readonly AppDbContext _context;
        public TouristRouteRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TouristRoute> GetTouristRoutes()//返回所有旅游路线具体方法
        {
            return _context.TouristRoutes;
        }

        public TouristRoute GetSingleTouristRoute(Guid TouristRouteId)//返回单个旅游路线具体方法
        {
            return _context.TouristRoutes.FirstOrDefault(n => n.ID == TouristRouteId);
        }
    }
}
