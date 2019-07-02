using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMind.Web.Areas;

namespace MyMind.Web.Controllers
{
    public class TestController : BaseApiController
    {
        public IActionResult DatabaseInit()
        {
            return Json("Created");
        }
    }
}
