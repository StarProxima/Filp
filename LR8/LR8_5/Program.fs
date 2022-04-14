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


[<EntryPoint>]
let main argv =
    0