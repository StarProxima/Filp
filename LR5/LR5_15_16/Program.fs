open System

let rec nod x y =
    if x = 0 || y = 0 then x + y      
    else
        let newX = if x > y then x % y else x
        let newY = if x <= y then y % x else y
        nod newX newY



let primesFunc x func init =
    let rec pf x func init curPrime =
        if curPrime <= 0 then init
            
        else
            let newInit = if nod x curPrime = 1 then func init curPrime else init
            let newPrime = curPrime - 1
            pf x func newInit newPrime
    pf x func init x

let eulerFunc x =
    primesFunc x (fun x y -> x + 1) 0


[<EntryPoint>]
let main argv =
    printfn "Number: "
    let x = Console.ReadLine() |> Int32.Parse
    printfn "The product of mutually prime numbers: %d" (primesFunc x (fun x y -> x * y) 1)
    printfn "Euler number: %d" (eulerFunc x)
    0