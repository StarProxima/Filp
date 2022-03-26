open System

let elemCount list elem =
    let rec elemCountInternal list elem count  =
        match list with
        | [] -> count
        | elem0::t ->
            let newCount = if (elem0 = elem) then count + 1 else count
            elemCountInternal t elem newCount
    elemCountInternal list elem 0

let proc list =
    let rec procInternal list originalList elem =
        match list with
        | [] -> elem
        | elem0::t ->
            let newElem = if (elemCount originalList elem0) = 1 then elem0 else elem
            procInternal t originalList newElem
    procInternal list list list.Head

[<EntryPoint>]
let main argv =
    printfn "Number of items and list:"
    let list = Program.readList (Console.ReadLine() |> Convert.ToInt32)
   
    printfn "Result: %d" (proc list)
    0