open System

let proc list a b  =
    let rec procInternal list a b sum =
        match list with
        |[] -> sum
        | elem0::t ->
            let newSum = if elem0 > a && elem0 < b then sum + elem0 else sum
            procInternal t a b newSum
    procInternal list a b 0

[<EntryPoint>]
let main argv =
    printfn "Number of items and list:"
    let list = Program.readList (Console.ReadLine() |> Convert.ToInt32)

    printfn "a and b:"
    let a = Console.ReadLine() |> Convert.ToInt32
    let b = Console.ReadLine() |> Convert.ToInt32
   
    printf "%d" (proc list a b)
    0