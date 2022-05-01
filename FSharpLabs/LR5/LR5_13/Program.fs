open System

// Произведение цифр числа, рекурсия вверх
let rec multiplicationUp x =
    if x = 0 then 1
    else (x % 10) * multiplicationUp(x / 10)

// Произведение цифр числа, рекурсия вниз
let multiplicationDown x =
    let rec md x cur =
        if x = 0 then cur
        else
            let newCur = cur * (x % 10)
            let newX = x / 10
            md newX newCur
    md x 1

// Минимальная цифра числа, рекурсия вверх
let rec minNumberUp x =
    if x < 10 then x
    else min (x % 10) (minNumberUp (x / 10))

// Минимальная цифра числа, рекурсия вниз
let minNumberDown x =
    let rec mnd x min =
        if x = 0 then min
        else
            let newMin = if x % 10 < min then x % 10 else min
            let newX = x / 10
            mnd newX newMin
    mnd x (x % 10)

// Максимальная цифра числа, рекурсия вверх
let rec maxNumberUp x =
    if x < 10 then x
    else max (x % 10) (maxNumberUp (x / 10))

// Максимальная цифра числа, рекурсия вниз
let maxNumberDown x =
    let rec mnd x max =
        if x = 0 then max
        else
            let newMax = if x % 10 > max then x % 10 else max
            let newX = x / 10
            mnd newX newMax
    mnd x (x % 10)



[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите число")
    let x = Console.ReadLine() |> Int32.Parse
    Console.WriteLine("Произведение цифр числа, рекурсия вверх: {0}", multiplicationUp x)
    Console.WriteLine("Произведение цифр числа, рекурсия вниз: {0}", multiplicationDown x)
    Console.WriteLine("Минимальная цифра числа, рекурсия вверх: {0}", minNumberUp x)
    Console.WriteLine("Минимальная цифра числа, рекурсия вниз: {0}", minNumberDown x)
    Console.WriteLine("Максимальная цифра числа, рекурсия вверх: {0}", maxNumberUp x)
    Console.WriteLine("Максимальная цифра числа, рекурсия вниз: {0}", maxNumberDown x)
    0