using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMind.Web.Domain.Emotions.Services
{
    public interface IEmotionsService
    {
        IEnumerable<Emotion> GetAllEmotions();
    }
}
