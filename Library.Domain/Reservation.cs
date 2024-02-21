
using System.Diagnostics;
using System.Drawing;
using Library.Domain;
using Library.Framework;

namespace Library.Domain
{
    public class Reservation : Entity<ReservationId>
    {




        public enum ReservationState
        {
            Pending,
            Confirmed,
            Cancelled
        }



        public Reservation(Action<object> applier) : base(applier)
        {
        }

        protected override void When(object @event)
        {
          


        }
    }
}
