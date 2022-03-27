open System

let task3 (str:string) =
    let splitted = str.Split " "
    let rnd = System.Random()
    let res = Array.sortBy (fun x -> rnd.Next(0, 100)) splitted
    String.concat " " res

let task8 (str:string) =
    let splited = str.Split " "
    Array.fold (fun acc x -> if (String.length x) % 2 = 0 then acc+1 else acc) 0 splited

let task16 strArray =
    let cmprColots = function 
        | "White" -> 0
        | "Blue" -> 1
        | "Red" -> 2
    Array.sortBy cmprColots strArray

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
    printfn "Number of task: 1, 2 or 3: "
    let number = Console.ReadLine() |> Convert.ToInt32

    match number with
    | 1 ->
        printfn "String: "
        printfn "Result: %A" (task3 (Console.ReadLine()))
    | 2 -> 
        printfn "String: "
        printfn "Result: %A" (task8 (Console.ReadLine()))
    | 3 ->
        printfn "Count and StringArray: "
        printf "Result: %A" (task16 (createStrArray (Console.ReadLine() |> Convert.ToInt32)))

    0
