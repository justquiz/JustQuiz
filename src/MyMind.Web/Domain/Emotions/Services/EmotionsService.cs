using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMind.Web.Database;

namespace MyMind.Web.Domain.Emotions.Services
{
    public class EmotionsService : IEmotionsService
    {
        private readonly ISessionFactory _sessionFactory;

        public EmotionsService(ISessionFactory sessionFactory)
        {
            this._sessionFactory = sessionFactory;
        }

        public IEnumerable<Emotion> GetAllEmotions()
        {
            using (var session = this._sessionFactory.Create())
            {
                var emotions = session.Get<Emotion>();
                return emotions;
            }
        }
    }
}
