using System;

namespace MyMind.Web.Domain.Reasons
{
    public class Reason : Aggregate
    {
        public string Name { get; private set; }

        public Reason(string name)
        {
            Name = name;
        }
    }
}
