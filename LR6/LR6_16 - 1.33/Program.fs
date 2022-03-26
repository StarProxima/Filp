open System

let proc list  =
    let rec procInternal list isAlternating =
        match list with
        |[] -> isAlternating
        | elem0::elem1::t ->
            
            let newIsAlternating = if (elem0*elem1 < 0 && isAlternating) then true else false
            let newList = elem1::t
            procInternal newList newIsAlternating
        |_ -> isAlternating
    procInternal list true

[<EntryPoint>]
let main argv =
    printfn "Number of items and list:"
    let list = Program.readList (Console.ReadLine() |> Convert.ToInt32)
   
    printf "%b" (proc list)
    0