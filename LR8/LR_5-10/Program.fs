open System
open System.Text.RegularExpressions

type DriversLicense(
    firstName: string,
    lastName: string,
    series: int,
    number: int,
    expirationDate: DateTime) =

    member this.firstName = firstName
    member this.lastName = lastName
    member this.series = series
    member this.number = number
    member this.expirationDate = expirationDate

    override this.ToString() = $"Водительские права:
    Имя: {this.firstName}
    Фамилия: {this.lastName} 
    Серия: {this.series} 
    Номер: {this.number} 
    Дата истечения: {this.expirationDate.ToShortDateString()}"

    interface IComparable with
        member this.CompareTo(obj: obj): int = 
            match obj with
            | :? DriversLicense as licence -> if this.series = licence.series then this.number.CompareTo licence.number else this.series.CompareTo licence.series
            | _ -> invalidArg "obj" "Разные типы сравниваемых объектов" 

    override this.Equals(obj) =
        match obj with
        | :? DriversLicense as licence -> this.series = licence.series && this.number = licence.number
        | _ -> invalidArg "obj" "Разные типы сравниваемых объектов"

    override this.GetHashCode() =
        HashCode.Combine(series, number)

    // Кидает ошибку если строка не уд. регулярке
let assertRegex str regex =
    let reg = Regex(regex)
    if not (reg.IsMatch str) then
        invalidArg str $"Некорректная строка"

// Ввод поля в соотв. с регуляркой (пока не будет введено верно)
let rec input fieldName regex =
    printf $"{fieldName}: "
    let str = Console.ReadLine()
    try
        assertRegex str regex
        str
    with
    | e ->
        printfn "Ошибка: %s" (e.Message)
        input fieldName regex

let inputDriversLicense() =
    printfn "Водительские права - "
    let firstname = input "Имя" "^[a-zA-Zа-яА-Я]+$"
    let lastname = input "Фамилия" "^[a-zA-Zа-яА-Я]+$"
    let series = input "Серия" "^\d{4}$" |> Int32.Parse
    let number = input "Номер" "^\d{6}$" |> Int32.Parse
    let expirationDate = input "Дата окончания срока действия" "^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$" |> DateTime.Parse
    DriversLicense(firstname, lastname, series, number, expirationDate)
    




[<EntryPoint>]
let main argv =
    let licence1 = DriversLicense("Гиряндр", "Данилков", 1314, 678634, DateTime.Parse "16.04.2022")
    let licence2 = DriversLicense("НеГиряндр", "НеДанилков", 1314, 678635, DateTime.Parse "16.04.2022")
    Console.WriteLine(licence1)
    Console.WriteLine(licence1 <> licence2)
    let lic = inputDriversLicense()
    0