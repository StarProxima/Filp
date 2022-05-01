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

let shiftRight list n =
    let len = List.length list
    let newIndex idx = if idx - n < 0 then len + (idx - n) else idx - n 
    List.init len (fun index -> List.item (newIndex index) list)
    

[<EntryPoint>]
let main argv =
    printfn "Number of items and list:"
    let list = readList (Console.ReadLine() |> Convert.ToInt32)

    printfn "Result"
    writeList (shiftRight list 1)
    0