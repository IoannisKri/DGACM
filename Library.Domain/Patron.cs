
using System.ComponentModel;
using System.Diagnostics;
using Library.Domain;
using Library.Framework;

namespace Library.Domain
{

    public class Patron : AggregateRoot<PatronId>
    {
        public PatronName patronName { get; private set; } //ValueObject
        public HashSet<ReservationId> reservations { get; private set; }


        protected Patron(PatronId id, PatronName patronName)
        {


            Apply(new Events.PatronCreated
            {
                Id = id,
                patronName = patronName

            });
        }


        public static Patron CreatePatron(PatronId id, PatronName patronName)
        {
            return new Patron(  id,   patronName);
        }



        public void AddReservation(ReservationId reservationId)
        {
            Apply(new Events.PatronReservationAdded
            {
                Id = Id,
                reservationId = reservationId
            }) ;
        }


        protected override void When(object @event)
        {

            switch (@event)
            {
                case Events.PatronCreated e:
                    // initialize the aggregate root
                    Id = new PatronId(e.Id);
                    patronName = e.patronName;

                    reservations = new HashSet<ReservationId> { };
                    break;

                case Events.PatronReservationAdded e:
                   

                    reservations.Add(e.reservationId);
                    break;






            }
        }


        protected override void EnsureValidState()
        {



        }





    }

}
