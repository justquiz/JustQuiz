using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyMind.Web.Areas.Emotions
{
    public class EmotionsController : BaseApiController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}