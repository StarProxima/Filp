open System

let agent = MailboxProcessor.Start(fun inbox->
    let rec messageLoop() = async{
        let! msg = inbox.Receive()
        
        let str = 
            match msg with
            |"F#"|"Prolog"->"Подлиза"
            |other -> $"Чел ты, щас бы в 3022 юзать '{other}'"

        printfn "AI: %s" str
        return! messageLoop()
        }
    messageLoop()
    )

let rec dialogue() =
    let input = Console.ReadLine().Trim()
    if input<>"" then
        agent.Post(input)
        dialogue()

[<EntryPoint>]
let main argv =
    printfn "Start a dialogue with artificial intelligence. Enter for closing the dialogue."
    dialogue()
    printfn "Thansk for using. Developed by OpenAI in 3022."
    0 