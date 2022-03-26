open System

let rec readList n = 
    if n=0 then []
    else
        let head = Console.ReadLine() |> Convert.ToInt32
        let tail = readList (n-1)
        head::tail

let rec printList = function
    | [] -> ()
    | head::tail -> 
        printfn "%O" head
        printList tail

let proc3 list func =
    let rec proc3Internal list func curList =
        match list with
        | [] -> curList
        | elem0::t ->
            let elem1 = if t <> [] then t.Head else 1
            let elem2 = if t <> [] then (if t.Tail <> [] then t.Tail.Head else 1) else 1
            let newElem = func elem0 elem1 elem2
            let newlist = curList @ [newElem]
            // Сдвиг списка ещё на 2 вправо
            let shiftedList = if t <> [] then (if t.Tail <> [] then t.Tail.Tail else []) else []
            proc3Internal shiftedList func newlist
    proc3Internal list func []

[<EntryPoint>]
let main argv =
    printfn "Number of items and list:"
    let list = readList (Console.ReadLine() |> Convert.ToInt32)
    let new_list = proc3 list (fun x y z -> x + y + z)
    printfn "Result:"
    printList new_list
    0