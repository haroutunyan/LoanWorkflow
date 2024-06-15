using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.Events
{
    public abstract class AggregateRoot
    {
        private readonly List<DomainEvent> _changes = [];
        public IEnumerable<DomainEvent> GetUncommittedChanges() => _changes;
        public void MarkChangesAsCommitted() => _changes.Clear();

        protected void ApplyChange(DomainEvent @event, bool isNew = true)
        {
            var method = GetType().GetMethod("Apply", [@event.GetType()])
                ?? throw new InvalidOperationException($"Apply method not found for event type {@event.GetType().Name}");

            method.Invoke(this, [@event]);
            if (isNew)
                _changes.Add(@event);
        }

        public void LoadFromHistory(IEnumerable<DomainEvent> history)
        {
            foreach (var e in history)
            {
                ApplyChange(e, false);
            }
        }
    }


}
