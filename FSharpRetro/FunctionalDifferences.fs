module FunctionalDifferences

open System

//Immutability
let immutable = 1

immutable <- 3 //Won't work

let mutable myVar = 1

myVar <- 3 //Works, but even intellisense colours it oddly to mark it as dangerous

//Nullability
type Person = {
    Name: string
    Birthdate: DateTime
}

let nullable : Person = null //Doesn't work, can't be null

//Structural equality
let myPerson1 = { Name = "Foo"; Birthdate = DateTime.Parse("2018-01-01") }
let myPerson2 = { Name = "Foo"; Birthdate = DateTime.Parse("2018-01-01") }

myPerson1 = myPerson2 //are these equal? Would they be in C#?

//No partial initialisation
let initFail : Person = { Name = "Foo" }