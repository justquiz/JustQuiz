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

        [HttpPost]
        public IActionResult GetEmotions()
        {
            using (var session = this._emotionsService.Create())
            {
                var emotions = session.Get<Emotion>();

                return Json(emotions);
            }
        }
    }
}