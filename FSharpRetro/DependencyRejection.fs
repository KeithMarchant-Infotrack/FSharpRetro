namespace DependencyRejection
module DB =
    let readReservations connectionString date = 
        List.Empty
    let createReservation connectionString reservation =
        true

module DependencyRejection =

    open System.Data.Common
    open System
    open DB

    // Let's assume we are trying to make a reservation at a restaurant
    // In our domain, we need to see if we have space for a reservation and then make it

    type Reservation = 
        {
            Date: DateTime;
            Quantity: int;
            IsAccepted: bool;
        }

    let connectionString = ""   

    let tryAccept capacity readReservations createReservation reservation = 
        let reservedSeats = readReservations reservation.Date |> List.sumBy (fun x -> x.Quantity)
        if reservedSeats + reservation.Quantity <= capacity
        then createReservation {reservation with IsAccepted = true } |> Some
        else None

      
    //This is dependency injection in C# (compiles to same IL). However, not functional  
    let tryAcceptComposition = 
        let read = DB.readReservations connectionString
        let create = DB.createReservation connectionString
        tryAccept 10 read create //The read/create functions can be impure, making tryAccept impure when we want it to be pure

    
    //Okay, so how could we make this functional?
    //Quick refactor, we've eliminated the DB operations, makes this a pure function, easy to test
    let tryAcceptFunctional capacity reservations reservation = 
        let reservedSeats = reservations |> List.sumBy (fun x -> x.Quantity)
        if reservedSeats + reservation.Quantity <= capacity
        then { reservation with IsAccepted = true } |> Some
        else None
    
    //Helper function (think back to algebra for this one)
    // (a' -> b' -> c') -> b' -> a' -> c'
    let flip f x y = f y x

    //Impure functions surrounding a pure function, ports & adapters architecture
    let tryAcceptFunctionalComposition reservation = 
        reservation.Date
        |> DB.readReservations connectionString
        |> flip (tryAcceptFunctional 10) reservation
        |> Option.map (DB.createReservation connectionString)

    (*
    This may take some considering, 
    but in functional programming we're pushing IO to the ouside of our program
    Traditional DI hides IO (and therefore side effects) at the base layers 
    and then you need unit tests, etc to mock and apply core functions
    In functional languages we can test just the pure functions, 
    impurity should be constrained to simple IO operations
    *)

