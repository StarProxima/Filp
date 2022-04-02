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


//let proc =
//    let rec procInternal curList candidate ind =
//        if(ind >= 100) then curList
//        else
//            let newCurList = if (candidate % 13 = 0 || candidate % 17 = 0) then curList @ [candidate] else curList
//            let newInd = if (candidate % 13 = 0 || candidate % 17 = 0) then ind + 1 else ind
//            let newCandidate = candidate + 1
//            procInternal newCurList newCandidate newInd
//    procInternal [] 1 0

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
    List.sortBy (fun x -> (countOfTriple x)) list

let maxASCII (str:string) =
    let rec maxASCIIInternal index (count:int) =
        match index with
        | index when index >= str.Length - 1 -> count
        |_ ->
            let newCount = if (str.[index] |> Convert.ToInt32)  > count then (str.[index] |> Convert.ToInt32) else count
            let newIndex = index + 1
            maxASCIIInternal newIndex newCount
    maxASCIIInternal 0 ('A' |> Convert.ToInt32)
    
let sumRazn (str:string) =
    let rec task9Internal index index2 count =
        match index with
        | index when index2 <= index -> count
        |_ ->
            let newCount = (str.[index] |> Convert.ToInt32) - (str.[index2] |> Convert.ToInt32) + count
            let newIndex = index + 1
            let newIndex2 = index2 - 1
            task9Internal newIndex  newIndex2 newCount
    task9Internal 0 ((str.Length) - 1) 0

let task9 list =
    List.sortBy (fun x -> (maxASCII x - sumRazn x)*(maxASCII x - sumRazn x) ) list
            
[<EntryPoint>]
let main argv =
    printfn "Number of items and strings:"
    let list = readListStr (Console.ReadLine() |> Convert.ToInt32)
    printfn "Number of sort: 1 or 2: "
    let number = 1
    match number with
    | 1 ->
        printfn "Sort1: "
        printfn "Result: %A" (task9 list)
        
    | 2 -> 
        printfn "Sort2: "
        printfn "Result: %A" (sortByTriple list)
    | _ ->
        printfn "No comments: "
    0