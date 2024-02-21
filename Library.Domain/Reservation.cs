
using System.Diagnostics;
using System.Drawing;
using Library.Domain;
using Library.Framework;
using static Library.Domain.Reservation;

namespace Library.Domain
{
    public class Reservation : Entity<ReservationId>
    {



        public BookId parentId { get; private set; }
        public Price reservationPrice { get; private set; }
        public decimal totalReservationCost { get; private set; }
        public int reservationDays { get; private set; }
        public ReservationDate dateStart { get; private set; }
        public ReservationDate dateEnd { get; private set; }
        public PatronId patronId { get; private set; }
        public ReservationState state { get; internal set; }
        public bool isPaid { get; internal set; }


        public enum ReservationState
        {
            Pending,
            Confirmed,
            Due,
            Cancelled
        }



        public Reservation(Action<object> applier) : base(applier)
        {
        }


        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.ReservationRequested e:
                    parentId = new BookId(e.Id);
                    Id = new ReservationId(e.reservationId);
                    reservationPrice = e.bookPrice;
                    dateStart = e.dateStart;
                    dateEnd = e.dateEnd;
                    reservationDays = (e.dateEnd.Value.Date - e.dateStart.Value.Date).Days;
                    totalReservationCost =  reservationPrice.Amount * reservationDays;
                    state = ReservationState.Pending;
                    isPaid = false;
                    break;
                case Events.ReservationPaid e:
                    isPaid = true;
                    state = ReservationState.Confirmed;
               
                    break;

            }


        }
    }
}