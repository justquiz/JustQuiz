using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMind.Web.Database;
using MyMind.Web.Domain.Emotions;

namespace MyMind.Web.Areas.Emotions
{
    public class EmotionsController : BaseApiController
    {
        private readonly ISessionFactory _sessionFactory;

        public EmotionsController(ISessionFactory sessionFactory)
            => this._sessionFactory = sessionFactory;

        [HttpPost]
        public IActionResult GetEmotions()
        {
            using (var session = this._sessionFactory.Create())
            {
                var emotions = session.Get<Emotion>();

                if (emotions != null && emotions.Any())
                {
                    return Json(emotions);
                }
            }

            return Json("Cannot return empty database. Database must include elements.");
        }
    }
}