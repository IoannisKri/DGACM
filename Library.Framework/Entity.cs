using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Library.Framework
{


    public abstract class Entity<TId> : IInternalEventHandler where TId : Value<TId>
    {
        /*
        I add a constructor to this class that will accept an applier delegate.
        Since I always instantiate child entities from the aggregate root, I will pass the Apply method of the root to all entities.
        Then, an entity will use double dispatch to inform the aggregate root of events that the entity will be producing.
        By doing this, I ensure that the aggregate root can also handle events from its child entities
        Just like in the AggregateRoot class, EnsureValidState method ensures that there is no consistency violation within the aggregate boundaries
        All new events are added to the single list of changes for the whole aggregate.
         */
        private readonly Action<object> _applier;

        public TId Id { get; protected set; }

        protected Entity(Action<object> applier) => _applier = applier;

        protected abstract void When(object @event);

        protected void Apply(object @event)
        {
            When(@event);
            _applier(@event);
        }

        void IInternalEventHandler.Handle(object @event) => When(@event);
    }
}

