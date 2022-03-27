open System

let task3 (str:string) =
    let splitted = str.Split " "
    let rnd = System.Random()
    let res = Array.sortBy (fun x -> rnd.Next(0, 100)) splitted
    String.concat " " res


let createStrArray n =
    let rec createStrArrayInternal tn strArray =
        if(tn >= n) then strArray
        else
            let str = Console.ReadLine()
            let newN = tn+1
            let newStrArray = Array.append strArray [|str|]
            createStrArrayInternal newN newStrArray
    createStrArrayInternal 0 [||]
    
         
[<EntryPoint>]
let main argv =
    printfn "String: "

    let str =Console.ReadLine()
    printfn "Result: "
    printfn "%A" (task3 str)
    
    0
