module FirstClassFunctions

// ======== Functions ========
// The "let" keyword also defines a named function.
let square x = x * x          
square 3                      

let add x y = x + y           // don't use add (x,y)! It means something
                              // completely different.
add 2 3                       

let add2 = add 2              // Partial application

add2 3                        

//math: f(a` -> b`) -> x:a` -> b`
let math f x = f(x)           // Functions returning functions

math (fun y -> y * y) 2       // Functions as parameters

math add2 3


// Functions stored in data structures (list of functions)
let funList = [ square; add2 ]

// Functions returning functions
let checkFor item =
    let functionToReturn = fun lst ->
                           List.exists (fun a -> a = item) lst
    functionToReturn

let checkFor7 = checkFor 7
let intList = [ 1; 2; 3; 4; 5; 6 ]
checkFor7 intList


//PigLatin example of function passing

open System

let startsWithVowel firstChar = Seq.contains firstChar "AEIOUaeiou"
let toPigLatin (name : string) = 
    if (startsWithVowel name.[0]) then name + "yay"
    else String.Concat(name.Substring(0), name.[0], "ay")

let makeThemPigLatin names = 
    names
    |> List.map toPigLatin

["Apple"; "Banana"]
|> makeThemPigLatin
|> List.map (printfn "%s") |> ignore



