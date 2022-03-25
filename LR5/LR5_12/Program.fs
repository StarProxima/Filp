open System

[<EntryPoint>]
let main argv =
    printfn "Какой ваш любимый язык программирования?"
    let choiseL str  = 
        match str with
        |"F#"|"Prolog"->"Подлиза"
        |_->"!Подлиза"
      
    //12.1
    (Console.ReadLine>>choiseL>>Console.WriteLine)()
    
    //12.2
    let f input (output:string->unit) choiseL = output(choiseL(input()))
    f Console.ReadLine Console.WriteLine choiseL
    0