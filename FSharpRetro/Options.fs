module Options

//F# doesn't use Nulls, instead you must state an object is either present or not, denoted by None
//In C# null is an object, and contains the type methods of its source object. 
//E.g. string x = null has all string methods

let divide x y = 
    match y with 
    | 0 -> None
    | _ -> Some (x/y)

//Using this code requires us to handle a possible None, but we know it's possible based on the method description
//divide: int -> int -> int option

//use pattern matching to handle the null
let a = 10
let b = 0

match divide a b with
| Some s -> printfn "%i divided by %i equals %i" a b s
| None -> printfn "%i is indivisible by %i" a b



