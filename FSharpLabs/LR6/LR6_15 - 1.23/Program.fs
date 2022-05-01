open System

let proc list  =
    let rec procInternal list min1 min2 =
        match list with
        | [] -> (min1,min2)
        | elem::t ->
            let newMin2 = if (elem <= min1) then min1 else min2
            let newMin1 = if (elem <= min1) then elem else min1
            procInternal t newMin1 newMin2
    procInternal list list.Tail.Head list.Head

let print data =
    match data with
    | (a,b) -> printf "%d , %d" a b

[<EntryPoint>]
let main argv =
    printfn "Number of items and list:"
    let list = Program.readList (Console.ReadLine() |> Convert.ToInt32)
    let data = proc list
    print data
    0