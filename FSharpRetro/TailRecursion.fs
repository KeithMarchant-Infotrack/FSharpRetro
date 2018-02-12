module TailRecursion

//Recursion chews up the stack, eventually overflows (but not in our case)
let rec factorial x = 
    if x <= 1 then
        1
    else 
        x * factorial (x - 1)
   
factorial 10

//This is actually a loop, the accumulator handles keeping rack of our progress so recursion is optimised out
//No stack space used at all
let tailFactorial x = 
    let rec tailRecursiveFactorial x acc = 
        if x <= 1 then
            1
        else
            tailRecursiveFactorial (x - 1) (acc * x)
    tailRecursiveFactorial x 1

tailFactorial 10
