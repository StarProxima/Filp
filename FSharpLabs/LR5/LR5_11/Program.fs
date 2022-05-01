open System

let choiseL str =
    match str with
    |"F#"|"Prolog"->"Подлиза"
    |_->"!Подлиза"

[<EntryPoint>]
let main argv =
    printfn "Какой ваш любимый язык программирования?"
    let ans = Console.ReadLine()
    Console.WriteLine(choiseL ans)
    0 