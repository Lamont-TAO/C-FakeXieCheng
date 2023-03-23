using FakeXieCheng.NET3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.NET3.Services
{
    public interface ITouristRouteRepository//要主动添加public，以便外部引用！
    {
        IEnumerable<TouristRoute> GetTouristRoutes();//IEnumerable枚举类型。返回一组旅游路线
        TouristRoute GetSingleTouristRoute(Guid TouristRouteId);//根据旅游路线ID返回一个唯一的旅游路线对象
        
    } 
}
