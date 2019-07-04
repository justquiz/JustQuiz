using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMind.Web.Areas;
using MyMind.Web.Database;
using MyMind.Web.Domain.Emotions;

namespace MyMind.Web.Controllers
{
    public class TestController : BaseApiController
    {
        private readonly ISessionFactory _sessionFactory;

        public TestController(ISessionFactory sessionFactory)
        {
            this._sessionFactory = sessionFactory;
        }

        [HttpGet]
        public IActionResult DataBaseClear()
        {
            using (var session = this._sessionFactory.Create())
            {
                var emotions = session.Get<Emotion>();

                foreach (var emotion in emotions)
                {
                    session.Delete<Emotion>(emotion);
                }
            }

            return Json("Deleted");
        }

        [HttpGet]
        public IActionResult DatabaseInit()
        {
            var emotions = new List<Emotion>
            {
                new Emotion("Playful", EmotionType.Happy),
                new Emotion("Interested", EmotionType.Happy),
                new Emotion("Proud", EmotionType.Happy),
                new Emotion("Powerful", EmotionType.Happy),
                new Emotion("Peaceful", EmotionType.Happy),
                new Emotion("Optimistic", EmotionType.Happy),

                new Emotion("Lonely", EmotionType.Sad),
                new Emotion("Guilty", EmotionType.Sad),
                new Emotion("Depressed", EmotionType.Sad),
                new Emotion("Disappointed", EmotionType.Sad),

                new Emotion("Awful", EmotionType.Disgusted),
                new Emotion("disapproving", EmotionType.Disgusted),

                new Emotion("Frustrated", EmotionType.Angry),
                new Emotion("Aggressive", EmotionType.Angry),
                new Emotion("Mad", EmotionType.Angry),
                new Emotion("Humiliated", EmotionType.Angry),

                new Emotion("Insecure", EmotionType.Fearful),
                new Emotion("Anxious", EmotionType.Fearful),
                new Emotion("Scared", EmotionType.Fearful),
                new Emotion("Weak", EmotionType.Fearful),
                new Emotion("Rejected", EmotionType.Fearful),

                new Emotion("Bored", EmotionType.Bad),
                new Emotion("Stressed", EmotionType.Bad),
                new Emotion("Tired", EmotionType.Bad),

                new Emotion("Confused", EmotionType.Surprised),
                new Emotion("Amazed", EmotionType.Surprised),
                new Emotion("Excited", EmotionType.Surprised),
            };

            using (var session = this._sessionFactory.Create())
            {
                if(session.Get<Emotion>().Any())
                {
                    return Json("Cannot init not empty database. Database must be empty.");
                } 

                emotions.ForEach(session.Add);
            }


            return Json("Created");
        }
    }
}
