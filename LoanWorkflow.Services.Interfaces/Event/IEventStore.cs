using LoanWorkflow.DAL.Entities.Event;
using LoanWorkflow.Services.Events;
using LoanWorkflow.Services.Interfaces.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.Interfaces.Event
{
    public interface IEventStore : IService<StoredEvent>
    {
        Task SaveEventsAsync(Guid aggregateId, IEnumerable<DomainEvent> events, int expectedVersion);
        Task<List<DomainEvent>> GetEventsForAggregateAsync(Guid aggregateId);
    }
}
