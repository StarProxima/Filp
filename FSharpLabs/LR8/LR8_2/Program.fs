





type Maybe<'T> =
    | Value of 'T   
    | Nothing

//Функтор
let MaybeFunctor func maybeValue =
    match maybeValue with
    | Value x -> Value(func x)
    | Nothing -> Nothing

//Аппликативный функтор
let ApplicativeMaybeFunctor maybeFunc maybeValue =
    match maybeFunc, maybeValue with
    | Value f, Value x -> Value(f x)
    | _ -> Nothing

//Монада
let MaybeMonade maybeValue func =
    match maybeValue with
    | Value x -> func x
    | Nothing -> Nothing

[<EntryPoint>]
let main argv =

    let id x = x
    let mb0 = 7
    let mb1 = Value(mb0)


    printfn "Первый закон функтора"
    printfn "%A - %A"(id mb1) (MaybeFunctor id mb1)
    printfn ""

    //Композиция подъемов эквивалентна подъему композиции.
    printfn "Второй закон функтора"
    let f x = x + 5
    let g x = x * 3
    printfn "%A - %A"(MaybeFunctor g (MaybeFunctor f mb1)) (MaybeFunctor (f >> g) mb1)
    printfn ""

    //Применение поднятой функции id к поднятому значению эквивалентно применению неподнятой функции id к неподнятому значению.
    printfn "Первый закон аппликативного функтора"
    let mbId = Value(fun x -> x)
    printfn "%A - %A" (id mb1) (ApplicativeMaybeFunctor mbId mb1)
    printfn ""

    printfn "Второй закон аппликативного функтора"
    let func x = x * 3
    let optfunc = Value(func)
    printfn "%A - %A" (ApplicativeMaybeFunctor optfunc mb1) (Value(func mb0))
    printfn ""

    //Третий закон аппликативного функтора не выполняется так как у ApplicativeMaybeFunctor нельзя менять аргументы местами

    //Четвертый закон аппликативного функтора не выполняется так как ApplicativeMaybeFunctor не ассоциативна
    0