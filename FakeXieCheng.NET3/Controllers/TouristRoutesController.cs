using FakeXieCheng.NET3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.NET3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //我们需要做的：
    //绑定数据模型-依赖注入调用数据仓库 
    public class TouristRoutesController : ControllerBase
    {
        private ITouristRouteRepository _touristRouteRepository;

        //构造函数传参
        public TouristRoutesController(ITouristRouteRepository touristRouteRepository)
        {
            _touristRouteRepository = touristRouteRepository;
        }

        /// <summary>
        /// 获取全部的旅游线路
        /// </summary>
        /// <returns></returns>
        //通过传递过来的参数，然后写了一个获取方法
        [HttpGet]
        public IActionResult GetTouristRoutes()
        {
            var touristRoutesFromRepo = _touristRouteRepository.GetTouristRoutes();
            if(touristRoutesFromRepo == null || touristRoutesFromRepo.Count() <= 0)
            {
                return NotFound("没有旅游路线");
            }
            else
            {
                return Ok(touristRoutesFromRepo);
            }
            
        }


        /// <summary>
        /// 根据ID获取单独一个路线
        /// </summary>
        /// <param name="touristRouteId"></param>
        /// <returns></returns>
        //如果控制器中的函数不唯一那么url上的访问方式将是：api/touristroutes/{touristRouteId}
        [HttpGet("{touristRouteId:Guid}")]
        public IActionResult GetTouristRoutesById(Guid touristRouteId)
        {

            var touristRouteFromRepo = _touristRouteRepository.GetSingleTouristRoute(touristRouteId);
            if(touristRouteFromRepo == null)
            {
                return NotFound($"旅游路线{touristRouteId}找不到");
            }
            else
            {
                return Ok(touristRouteFromRepo);
            }

            
        }
    }
}
