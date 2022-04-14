open System

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

    




[<EntryPoint>]
let main argv =
    let licence1 = DriversLicense("Гиряндр", "Данилков", 1314, 678634, DateTime.Parse "16.04.2022")
    let licence2 = DriversLicense("НеГиряндр", "НеДанилков", 1314, 678635, DateTime.Parse "16.04.2022")
    Console.WriteLine(licence1)
    Console.WriteLine(licence1 <> licence2)
    0