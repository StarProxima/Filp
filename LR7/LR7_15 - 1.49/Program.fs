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

let isPrime x =
    let rec isPrimeInternal divCandidate =
        if divCandidate >= x then true
        else
            if (x % divCandidate = 0) then false
            else 
                let newDivCandidate = divCandidate + 1
                isPrimeInternal newDivCandidate
    isPrimeInternal 2

let dividersFunc x =
    let rec dividersFuncInternal curList divCandidate =
        if divCandidate > x then curList
        else
            let newCurList = if (x % divCandidate = 0 && isPrime divCandidate) then curList @ [divCandidate] else curList
            let newDivCandidate = divCandidate + 1
            dividersFuncInternal newCurList newDivCandidate
    dividersFuncInternal [] 1
        
let proc list =
    List.distinct ( List.fold  (fun acc x -> List.append acc (dividersFunc x)) [] list )

[<EntryPoint>]
let main argv =
    printfn "Number of items and list:"
    let list = readList (Console.ReadLine() |> Convert.ToInt32)
    
    printfn "Result"
    writeList (proc list)
    0