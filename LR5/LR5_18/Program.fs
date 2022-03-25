open System


let prime n =
   let rec p n div =
       if (div>=n) then true
       else 
           if (n % div=0) then false
           else 
               let newDiv = div + 1
               p n newDiv
   p n 2 


let dividersFunc x func init =
    let rec df x func init curDiv =
        if curDiv = 0 then init
        else
            let newInit= if x % curDiv = 0 then func init curDiv else init
            let newDiv = curDiv - 1
            df x func newInit newDiv
    df x func init x

let rec nod x y =
    if x = 0 || y = 0 then x + y      
    else
        let newX = if x > y then x % y else x
        let newY = if x <= y then y % x else y
        nod newX newY

let primesFunc x func init =
    let rec pf x func init curPrime =
        if curPrime <= 0 then init
            
        else
            let newInit = if nod x curPrime = 1 then func init curPrime else init
            let newPrime = curPrime - 1
            pf x func newInit newPrime
    pf x func init x

// Произведение цифр числа, рекурсия вниз
let multiplicationDownWithPredicate x predicate =
    let rec md x cur =
        if x = 0 then cur
        else
            let newCur = if predicate (x % 10) then cur * (x % 10) else cur
            printfn "a: %d" newCur
            let newX = x / 10
            md newX newCur
    md x 1
    

// LR5_17.1- Обход делителей числа с условием
let dividersFuncWithPredicate x predicate func init =
    let func1 init cur = if predicate cur then func init cur else init
    dividersFunc x func1 init

// LR5_17.2 - Обход взаимнопростых чисел с условием
let primesFuncWithPredicate x predicate func init =
    let func1 init cur = if predicate cur then func init cur else init
    primesFunc x func1 init

[<EntryPoint>]
let main argv =
    
    printfn "Number: "
    let x = Console.ReadLine() |> Int32.Parse

    //Найти максимальный простой делитель числа.
    let method1 = dividersFuncWithPredicate x (fun x -> prime x) (fun x y -> max x y) 0
    printfn "Result1: %d" method1

    //Найти произведение цифр числа, не делящихся на 5
    let method2 = multiplicationDownWithPredicate x (fun x -> x % 5 > 0)
    printfn "Result2: %d" method2

    0