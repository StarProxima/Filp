open System


let rec printList1 = function
    | [] -> ()
    | head::tail -> 
        let elem = if (tail <> []) then tail.Head else head
        if(tail <> []) then
            printfn "%O" elem
            printList1 tail.Tail
        else
            printList1 tail
    

let rec printList2 = function
    | [] -> ()
    | head::tail -> 
        let elem = head
        printfn "%O" elem
        let nextList = if tail <> [] then tail.Tail else tail
        printList2 nextList

[<EntryPoint>]
let main argv =
    printfn "Number of items and list:"
    let list = Program.readList(Console.ReadLine() |> Convert.ToInt32)
    
    printfn "Result:"
    printfn "Even:"
    printList1 list
    printfn "Uneven:"
    printList2 list
    0