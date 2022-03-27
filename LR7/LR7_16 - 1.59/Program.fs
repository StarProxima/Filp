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

let proc list =
    List.choose (fun x ->
    match x with
    | x when x < 100 && x>=0 && (List.filter(fun a -> a=x) list).Length > 2 -> Some(x*x)
    | _ -> None
    ) (List.distinct list)
    

[<EntryPoint>]
let main argv =
    printfn "Number of items and list:"
    let list = readList (Console.ReadLine() |> Convert.ToInt32)

    printfn "Result"
    writeList (proc list)
    0