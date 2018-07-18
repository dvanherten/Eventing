using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneThingWell.Eventing
{
    public interface IEventStore
    {
        Task SaveEvents(Guid streamId, IEnumerable<Event> uncommittedChanges, int expectedVersion);

        Task<ICollection<Event>> GetStreamEvents(Guid streamId);
    }
}
