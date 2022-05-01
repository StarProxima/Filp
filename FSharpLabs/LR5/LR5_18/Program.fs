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

// Произведение цифр числа, рекурсия вниз
let multiplicationDownWithPredicate x predicate =
    let rec md x cur =
        if x = 0 then cur
        else
            let newCur = if predicate (x % 10) then cur * (x % 10) else cur
            let newX = x / 10
            md newX newCur
    md x 1
    

let dividersFuncWithPredicate x predicate func init =
    let func1 init cur = if predicate cur then func init cur else init
    dividersFunc x func1 init

let method3Func x = nod (dividersFuncWithPredicate x (fun x -> x%2 > 0 && not(prime x)) (fun x y -> max x y) 1) (multiplicationDownWithPredicate x (fun x -> true))

[<EntryPoint>]
let main argv =
    
    printfn "Number: "
    let x = Console.ReadLine() |> Int32.Parse

    //Найти максимальный простой делитель числа.
    let method1 = dividersFuncWithPredicate x (fun x -> prime x) (fun x y -> max x y) 0
    printfn "Result1: %d" method1

    //Найти произведение цифр числа, не делящихся на 5.
    let method2 = multiplicationDownWithPredicate x (fun x -> x % 5 > 0)
    printfn "Result2: %d" method2

    //Найти НОД максимального нечетного непростого делителя числа и прозведения цифр данного числа.
    let method3 = method3Func x
    printfn "Result3: %d" method3 

    0