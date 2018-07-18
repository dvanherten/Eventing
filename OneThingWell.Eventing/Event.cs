using System;
using System.Collections.Generic;
using System.Text;

namespace OneThingWell.Eventing
{
    public abstract class Event
    {
        public Guid EventId { get; }
        public DateTime EventDate { get; }

        protected Event()
        {
            EventId = Guid.NewGuid();
            EventDate = DateTime.UtcNow;
        }
    }
}
