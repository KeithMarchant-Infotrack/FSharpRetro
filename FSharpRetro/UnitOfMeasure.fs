module UnitOfMeasure

[<Measure>] type cm
[<Measure>] type inch
[<Measure>] type m
[<Measure>] type sec
[<Measure>] type kg

let x = 1<cm>    // int
let y = 1.0<cm>  // float
let z = 1.0m<cm> // decimal 


let distance = 1.0<m>    
let time = 2.0<sec>    
let speed = distance / time  
let acceleration = speed / time
let mass = 5.0<kg>    
let force = mass * speed/time

// type inference for result
let distance2 = distance * 2.0

// type inference for input and output
let addThreeMetres m = 
    m + 3.0<m> 

addThreeMetres 1.0        //error
addThreeMetres 1.0<cm>  //error
addThreeMetres 1.0<m>  //OK

