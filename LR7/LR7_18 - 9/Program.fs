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


let proc =
    let rec procInternal curList candidate ind =
        if(ind >= 100) then curList
        else
            let newCurList = if (candidate % 13 = 0 || candidate % 17 = 0) then curList @ [candidate] else curList
            let newInd = if (candidate % 13 = 0 || candidate % 17 = 0) then ind + 1 else ind
            let newCandidate = candidate + 1
            procInternal newCurList newCandidate newInd
    procInternal [] 1 0
            
[<EntryPoint>]
let main argv =
    //printfn "Number of items and list:"
    //let list = readList (Console.ReadLine() |> Convert.ToInt32)

    printfn "Result"
    writeList (proc)
    0