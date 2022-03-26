open System

let proc list1 list2 =
    let rec procInternal list1 list2 count =
        match list1 with
        | [] -> count
        | elem1::t1 ->
            match list2 with
            | [] -> count
            | elem2::t2 ->
                let newCount = if elem1 = elem2 then count + 1 else count 
                procInternal t1 t2 newCount
    procInternal list1 list2 0

[<EntryPoint>]
let main argv =
    printfn "Number of items and list1:"
    let list1 = Program.readList (Console.ReadLine() |> Convert.ToInt32)
    printfn "Number of items and list2:"
    let list2 = Program.readList (Console.ReadLine() |> Convert.ToInt32)
   
    printfn "Result: %d" (proc list1 list2)
    0