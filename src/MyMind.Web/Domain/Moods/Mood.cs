using System;

namespace MyMind.Web.Domain.Moods
{
    public class Mood : Aggregate
    {
        //public Guid UserId { get; private set; }
        public DateTime Date { get; private set; }
        public Guid ReasonId { get; private set; }
        public Guid EmotionId { get; private set; }

        public Mood(/*Guid userId,*/ DateTime date, Guid reasonId, Guid emotionId)
        {
            //UserId = userId;
            Date = date;
            ReasonId = reasonId;
            EmotionId = emotionId;
        }
    }
}
