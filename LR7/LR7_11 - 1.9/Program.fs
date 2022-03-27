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

let trimListByLastMin list =
    List.init (List.findIndexBack (fun x -> x = List.min list) list) (fun index -> List.item index list)
    

[<EntryPoint>]
let main argv =
    printfn "Number of items and list:"
    let list = readList (Console.ReadLine() |> Convert.ToInt32)

    printfn "Result"
    writeList (trimListByLastMin list)
    0