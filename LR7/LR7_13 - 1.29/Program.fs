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

let proc list a b =
    if List.max list > a && List.max list < b then true else false
    

[<EntryPoint>]
let main argv =
    printfn "Number of items and list:"
    let list = readList (Console.ReadLine() |> Convert.ToInt32)
    printfn "a and b:"
    let a = (Console.ReadLine() |> Convert.ToInt32)
    let b = (Console.ReadLine() |> Convert.ToInt32)
    printfn "Result"
    printf "%b" (proc list a b)
    0