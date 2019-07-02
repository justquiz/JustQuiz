using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMind.Web.Domain
{
    public abstract class Aggregate
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }

        protected Aggregate()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }
    }
}
