open System

let ChoiceFunction  y x = 
    match y with
    | 1 -> Program.dividersFuncWithPredicate x (fun x -> Program.prime x) (fun x y -> max x y) 0
    | 2 -> Program.multiplicationDownWithPredicate x (fun x -> x % 5 > 0)
    | _ -> Program.method3Func x

[<EntryPoint>]
let main argv =

Console.WriteLine("Введите номер функции и число: ")
let data = (Console.ReadLine() |> Int32.Parse, Console.ReadLine() |> Int32.Parse)
let result = ChoiceFunction (fst data) (snd data)
printfn "Result: %d"  result   
0