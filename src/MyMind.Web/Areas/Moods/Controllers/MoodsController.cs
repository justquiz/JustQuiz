using Microsoft.AspNetCore.Mvc;

namespace MyMind.Web.Areas.Moods.Controllers
{
    public class MoodsController : BaseApiController
    {
        [HttpGet]
        public IActionResult Test(string q)
        {
            return Json(q);
        }
    }
}
