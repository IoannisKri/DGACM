# DGACM Assignment

Dear reviewer, I hope you enjoy going through this repository while reviewing my submitted exercise. As always, it's possible that certain things could have been done in a better way, but taking the time constraint into consideration, I hope that the result is satisfactory.


## Design Approach

In order to have an effective DDD solution, I tried to group the components in aggregates according to their corresponding behaviours. My main focus is to always ensure the system's state validity and potentially set a good starting point for potential future improvements.

I tried to approach the problem in a behaviour-centric instead of a data/hierarchy driven approach and in the same time keep it as simple as possible. I aimed to leverage certain best practices and apply extensive unit testing.

Regarding documentation, several comments can be found inline and this README file can be used as a high level guideline.

### DDD

I have identified the following components:

1.Book
2.Reservation
3.Patron

In my opinion, Book in this case is an Aggregate Root which will have Reservations attached to it as child entities. The reason for this decision is that the Book Aggregate will not allow Patrons to reserve it while it's not available due to other Reservations. Each Reservation will reference its Patron by Id.



Patron on the other hand will be an Aggregate Root of his own and the corresponding Reservations will only reference Patreons by Id.

In order to have a functioning system, I will implement the following Value Objects

1.Book

-BookId

-BookTitle

-Quantity

-BookCategory


2.Reservation

-ReservationId

-ParentId (BookId)

-PatreonId

-StartDate

-DueDate

-ReservationCost


3.Patreon
-PatreonId
-PatreonFirstName
-PatreonLastName
-ListOfReservations (Only by reference)

Furthermore, the following logical steps will be in place:

1.RequestReservation
2.ConfirmReservation
3.FinalizeReservation

#Assumptions
 
Each reservation contains a single book

Book prices can change

The patron can only read the book within the library. this means that the reservation end date is the actual date when the book is made available again
 

## Implementation Approach

After having finished the design, I started implementing the simplest parts of the solution, namely Value Objects. Then moved to Aggregate Roots and finally applied the child Entities.

I tried committing in regular and meaningful intervals by using descriptive commit messages.

## Last minute note

Due to lack of time I couldn't implement all the features and tests I wanted. A sample Reservation workflow can be seen in Library Program.cs

Additionally I wanted to rearrange the project structure but it's too late for it

Each event is transmitted and can be seen in debug mode