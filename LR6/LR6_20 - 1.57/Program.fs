open System

let proc list  =
    let rec procInternal list sum count =
        match list with
        |[] -> count
        | elem0::t ->
            let newCount = if elem0 > sum then count + 1 else count
            let newSum = sum + elem0
            procInternal t newSum newCount
    procInternal list 0 0

[<EntryPoint>]
let main argv =
    printfn "Number of items and list:"
    let list = Program.readList (Console.ReadLine() |> Convert.ToInt32)
    
    printf "%d" (proc list)
    0