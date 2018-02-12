module Composition

let f (x:int) = float x * 3.0  // f is int->float
let g (x:float) = x > 4.0      // g is float->bool

// We can naively create

let d x = 
    let y = f(x)
    g(y)                   // return output of g

// And simplify that to

let h x = g ( f(x) ) // h is int->bool

//test
h 1
h 2


// But what if we take this further and make it generic?
let compose f g x = g ( f(x) )

// Good news, there's an operator
let (>>) f g x = g ( f(x) )

// Let's go back to where we started with math
let add n x = x + n
let subtract n x = x - n
let times n x = x * n
let add1subtract5 = add 1 >> subtract 5
let add1Times2 = add 1 >> times 2
let add5Times3 = add 5 >> times 3

//test
add1subtract5 6
add5Times3 1


