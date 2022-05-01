open System

let proc list  =
    let rec procInternal list curList max =
        match list with
        | [] -> curList
        | elem::t ->
            let newList = if (elem > max) && t <> [] then curList @ [t.Head] else curList
            let newMax = if (elem > max) then elem else max
            procInternal t newList newMax
    procInternal list [] list.Head

[<EntryPoint>]
let main argv =
    printfn "Number of items and list:"
    let list = Program.readList (Console.ReadLine() |> Convert.ToInt32)
   
    Program.printList (proc list)
    0