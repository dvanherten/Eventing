using System;
using System.Linq;
using System.Threading.Tasks;

namespace OneThingWell.Eventing
{
    public class Repository<T> : IRepository<T> where T : EventStream
    {
        private readonly IEventStore _storage;

        public Repository(IEventStore storage)
        {
            _storage = storage;
        }

        public async Task Save(EventStream eventStream, int expectedVersion)
        {
            await _storage.SaveEvents(eventStream.Id, eventStream.GetUncommittedChanges(), expectedVersion);
            eventStream.MarkChangesAsCommitted();
        }

        public async Task<T> GetByStreamId(Guid id)
        {
            var e = await _storage.GetStreamEvents(id);
            if (!e.Any())
                return null;

            var obj = (T)Activator.CreateInstance(typeof(T), true);
            obj.LoadFromHistory(e);
            return obj;
        }
    }
}
