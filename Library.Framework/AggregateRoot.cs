using System.Collections.Generic;
using System.Linq;

namespace Library.Framework
{
    public abstract class AggregateRoot<TId> : IInternalEventHandler
        where TId : Value<TId>
    {
        /*
        I want to ensure that all state transitions do not break our invariants.
        Therefore I put EnsureValidState method inside the Apply method so that it gets executed upon every event or state change.
        The need to protect its state only applies to the aggregate root entity because it must ensure that the whole aggregate state is correct.
         */

        public TId Id { get; protected set; }
        protected abstract void When(object @event);
        private readonly List<object> _changes;
        protected AggregateRoot() => _changes = new List<object>();
        protected void Apply(object @event)
        {
            When(@event);
            EnsureValidState();
            _changes.Add(@event);
        }
        public IEnumerable<object> GetChanges()
            => _changes.AsEnumerable();
        public void ClearChanges() => _changes.Clear();
        protected abstract void EnsureValidState();

        protected void ApplyToEntity(IInternalEventHandler entity, object @event) => entity?.Handle(@event);
        void IInternalEventHandler.Handle(object @event) => When(@event);

    }
}