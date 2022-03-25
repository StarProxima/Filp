open System

let dividersFunc x func init =
    let rec df x func init curDiv =
        if curDiv = 0 then init
        else
            let newInit= if x % curDiv = 0 then func init curDiv else init
            let newDiv = curDiv - 1
            df x func newInit newDiv
    df x func init x
        

[<EntryPoint>]
let main argv =
    Console.WriteLine("Number: ")
    let x = Console.ReadLine() |> Int32.Parse
    let result = dividersFunc x (fun x y -> x*y) 1
    Console.Write("Result: ")
    Console.WriteLine result
    0