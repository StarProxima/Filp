open System

let rec readListStr n = 
    if n=0 then []
    else
        let head = Console.ReadLine()
        let tail = readListStr (n-1)
        head::tail

let rec writeList = function
    | [] -> ()
    | head::tail -> 
        printfn "%s" head
        writeList tail


let proc =
    let rec procInternal curList candidate ind =
        if(ind >= 100) then curList
        else
            let newCurList = if (candidate % 13 = 0 || candidate % 17 = 0) then curList @ [candidate] else curList
            let newInd = if (candidate % 13 = 0 || candidate % 17 = 0) then ind + 1 else ind
            let newCandidate = candidate + 1
            procInternal newCurList newCandidate newInd
    procInternal [] 1 0

let countOfTriple (str:string) =
    let rec countOfTripleInternal index count =
        match index with
        | index when index >= str.Length - 2 -> count
        |_ ->
            let newCount = if str.[index] = str.[index+2] then count + 1 else count
            let newIndex = index + 1
            countOfTripleInternal newIndex newCount
    countOfTripleInternal 0 0

let sortByTriple list =
    List.sortBy (fun x -> -(countOfTriple x)) list
            
[<EntryPoint>]
let main argv =
    printfn "Number of items and strings:"
    let list = readListStr (Console.ReadLine() |> Convert.ToInt32)
    printfn "Number of sort: 1 or 2: "
    let number = 2
    match number with
    | 1 ->
        printfn "Sort1: "
        printfn "No Result:"
        
    | 2 -> 
        printfn "Sort2: "
        printfn "Result: %A" (sortByTriple list)
    | _ ->
        printfn "No comments: "
    0