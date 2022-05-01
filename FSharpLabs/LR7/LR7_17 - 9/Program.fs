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

let sumBeforeIndex list index = 
    List.fold (fun acc elem -> acc + elem) 0 (List.init index (fun idx -> List.item idx list)) 

let isFullSquare list x =
    (List.filter (fun a -> a*a = x) list).Length > 1

let isDividedIntoAllElemBefore list index =
    (List.filter (fun a -> (List.item index list) % a = 0) (List.init index (fun idx -> List.item idx list)) ).Length = index 
    

let proc list =
    let rec procInternal nowList curList ind =
        match nowList with
        | [] -> curList
        | elem::t ->
            let newCurList = if (elem > sumBeforeIndex list ind && isFullSquare list elem && isDividedIntoAllElemBefore list ind) then curList @ [elem] else curList
            let newInd = ind + 1
            procInternal t newCurList newInd
    procInternal list [] 0
            
[<EntryPoint>]
let main argv =
    printfn "Number of items and list:"
    let list = readList (Console.ReadLine() |> Convert.ToInt32)

    printfn "Result"
    writeList (proc list)
    0