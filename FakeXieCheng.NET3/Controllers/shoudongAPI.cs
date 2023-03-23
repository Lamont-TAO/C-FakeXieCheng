using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.NET3.Controllers
{
    [Route("api/shoudongapi")]//手动配置路径
    [Controller]
    public class shoudongAPI
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
