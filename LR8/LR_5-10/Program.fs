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



[<EntryPoint>]
let main argv =
    let licence = DriversLicense("Гиряндр", "Данилков", 1314, 678634, DateTime.Parse "16.04.2022")
    Console.WriteLine(licence)
    0