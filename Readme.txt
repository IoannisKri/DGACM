
DDD

I have identified the following components:

1.Book 2.Reservation 3.Patreon

In my opinion, Book in this case is an Aggregate Root which will have Reservations attached to it as child entities. The reason for this decision is that the Book Aggregate will not allow Patrons to reserve it while it's not available due to other Reservations. Each Reservation will reference its Patron by Id.

Patron on the other hand will be an Aggregate Root of his own and the corresponding Reservations will only reference Patreons by Id.

In order to have a functioning system, I will implement the following Value Objects

1.Book -BookId -BookTitle -Quantity -BookCategory

2.Reservation -ReservationId -ParentId (BookId) -PatreonId -StartDate -DueDate -ReservationCost

3.Patreon -PatreonId -PatreonFirstName -PatreonLastName -ListOfReservations (Only by reference)

Furthermore, the following logical steps will be in place:

1.RequestReservation 2.ConfirmReservation 3.FinalizeReservation

