open System

let rec readList n = 
    if n=0 then []
    else
        let head = Console.ReadLine() |> Convert.ToInt32
        let tail = readList (n-1)
        head::tail

let rec writeList = function
    | [] -> ()
    | head::tail -> 
        printfn "%O" head
        writeList tail

let writeEvenUneven list =
    List.iteri (fun i x -> if i % 2 = 0 then (printfn "%d" x)) list
    List.iteri (fun i x -> if i % 2 <> 0 then (printfn "%d" x)) list
    

[<EntryPoint>]
let main argv =
    printfn "Number of items and list:"
    let list = readList (Console.ReadLine() |> Convert.ToInt32)

    printfn "Result"
    writeEvenUneven list
    0