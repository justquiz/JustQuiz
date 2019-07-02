using System;

namespace MyMind.Web.Domain.Emotions
{
    public class Emotion : Aggregate
    {
        public string Name { get; private set; }
        public EmotionType Type { get; private set; }

        public Emotion(string name, EmotionType type)
        {
            Name = name;
            Type = type;
        }
    }
}
