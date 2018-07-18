using System;
using System.Threading.Tasks;

namespace OneThingWell.Eventing
{
    public interface IRepository<T> where T : EventStream
    {
        Task Save(EventStream eventStream, int expectedVersion);
        Task<T> GetByStreamId(Guid id);
    }
}