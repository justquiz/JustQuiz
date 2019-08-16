using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMind.Web.Database;
using MyMind.Web.Domain.Emotions;
using MyMind.Web.Domain.Emotions.Services;

namespace MyMind.Web.Areas.Emotions
{
    public class EmotionsController : BaseApiController
    {
        private readonly IEmotionsService _emotionsService;

        public EmotionsController(IEmotionsService emotionsService)
        {
            this._emotionsService = emotionsService;
        }

        [HttpGet]
        public IActionResult GetEmotions()
        {
            var emotions = this._emotionsService.GetAllEmotions();
            return Json(emotions);
        }
    }
}