open System
open FParsec

// Алгебраический тип для выражения (число, сумма, разность)
type Expr =
    | Number of float
    | Add of Expr * Expr
    | Sub of Expr * Expr

// Спарсить строку, возможно окруженную пробелами
let pstring_ws str = spaces >>. pstring str .>> spaces
// float без пробелов
let float_ws = spaces >>. pfloat .>> spaces

// Создаем парсер и ref переменную
let parser, parserRef = createParserForwardedToRef<Expr, unit>()

// 1. Спарсить пару с +, сохранить в Add
let parseAdd = tuple2 (parser .>> pstring_ws "+") parser |>> Add 
// 2. Спарсить пару с -, сохранить в Sub
let parseSub = tuple2 (parser .>> pstring_ws "-") parser |>> Sub
// Спарсить float и сохранить в Number
let parseNumber = float_ws |>> Number

// 3. Спарсить между скобками произвольные комбинации
let parseExpression = between (pstring_ws "(") (pstring_ws ")") (attempt parseAdd <|> parseSub)


// Пихаем в parserRef парсер произвольной комбинации float'ов и (3)
parserRef.Value <- parseNumber <|> parseExpression

// Функция вычисления выражения
let rec ParseExpr (e:Expr): float =
    match e with
    | Number(num) -> num
    | Add(x,y) ->
        let left = ParseExpr(x)
        let right = ParseExpr(y)
        left + right
        
    | Sub(x,y) ->
        let left = ParseExpr(x)
        let right = ParseExpr(y)
        left - right
        



[<EntryPoint>]
let main argv =
    printfn "Выражение: "
    let input = Console.ReadLine() 
    let expression = run parser input

    match expression with
    | Success (result, _, _) ->
        printfn "Преобразованное выражение: %A" (result)
        printfn "Ответ: %A" (ParseExpr result)
    | Failure (errorMsg, _, _) -> printfn "Ошибка: %s" errorMsg

    0