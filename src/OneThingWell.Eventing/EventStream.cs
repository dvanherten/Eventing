using System;
using System.Collections.Generic;

namespace OneThingWell.Eventing
{
    public abstract class EventStream
    {
        public abstract Guid Id { get; }

        private readonly List<Event> _changes = new List<Event>();
        public IReadOnlyCollection<Event> DomainEvents => _changes.AsReadOnly();
        public int Version { get; internal set; }
        
        public IEnumerable<Event> GetUncommittedChanges()
        {
            return _changes;
        }

        internal void MarkChangesAsCommitted()
        {
            _changes.Clear();
        }

        internal void LoadFromHistory(IEnumerable<Event> history)
        {
            foreach (var e in history)
                ApplyChange(e, false);
        }

        private void ApplyChange(Event @event, bool isNew)
        {
            ApplyChange(@event);
            if (isNew) _changes.Add(@event);
        }

        protected abstract void ApplyChange(Event @event);
    }
}
