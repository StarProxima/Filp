open System

let proc list  =
    let rec procInternal list maxUneven =
        match list with
        |[] -> maxUneven
        | elem0::t ->
            let newMaxUneven = if (elem0 > maxUneven && elem0 % 2 <> 0) then elem0 else maxUneven
            procInternal t newMaxUneven
    procInternal list 0

[<EntryPoint>]
let main argv =
    printfn "Number of items and list:"
    let list = Program.readList (Console.ReadLine() |> Convert.ToInt32)
    
    let result = proc list
    match result with
    | 0 -> printfn "There is no uneven max"
    |_ -> printf "%d" (proc list)
    0