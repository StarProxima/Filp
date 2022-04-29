open System
open System.Text.RegularExpressions
open System.Diagnostics

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

let assertRegex str regex =
    let reg = Regex(regex)
    if not (reg.IsMatch str) then
        invalidArg str $"Некорректная строка"

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
    
[<AbstractClass>]
type DLCollection() =
    abstract member search: DriversLicense -> TimeSpan

type ArrayDLCollection(list: DriversLicense list)=
    inherit DLCollection()
    member this.Array = Array.ofList list

    
    override this.search(lic) = 
        let l = Array.ofList list
        let watch = new Stopwatch()
        watch.Start()
        if (Array.exists (fun x-> x.Equals lic) l) then watch.Elapsed else TimeSpan.MinValue


type ListDLCollection(list: DriversLicense list)=
    inherit DLCollection()
    member this.List = list

    //override this.search(lic) = 
    //    List.exists (fun x-> x.Equals(lic)) this.List

    override this.search(lic) = 
        let l = list
        let watch = new Stopwatch()
        watch.Start()
        if (List.exists (fun x-> x.Equals lic) l) then watch.Elapsed else TimeSpan.MinValue

type BinListDLCollection(list: DriversLicense list)=
    inherit DLCollection()

    
    let rec binSearch (list:'DriversLicense list) (license:'DriversLicense) =
        match List.length list with
        | 0 -> false
        | i ->
            let middleIndx = i/2
            let middleElem = list.[middleIndx]
            match sign <| compare license middleElem with
            | 0 -> true
            | -1->binSearch list.[..middleIndx - 1] license
            | 1->binSearch list.[middleIndx + 1..] license  
    

    member this.List = List.sortBy (fun (x:DriversLicense) -> (x.series, x.number)) list 

   
    //override this.search(lic) =
        
    //    binSearch this.List lic

    override this.search(lic) = 
        let l = List.sortBy (fun (x:DriversLicense) -> (x.series, x.number)) list 
        let watch = new Stopwatch()
        watch.Start()
        if (binSearch l lic) then watch.Elapsed else TimeSpan.MinValue

type SetDLCollection(list: DriversLicense list)=
    inherit DLCollection()
    member this.Set = Set.ofList list

    //override this.search(set) = 
    //    Set.contains set this.Set
    override this.search(lic) = 
           let l = Set.ofList list
           let watch = new Stopwatch()
           watch.Start()
           if (Set.contains lic l) then watch.Elapsed else TimeSpan.MinValue



[<EntryPoint>]
let main argv =
    let licence1 = DriversLicense("Гиряндр", "Данилков", 1314, 678634, DateTime.Parse "16.04.2022")
    let licence2 = DriversLicense("НеГиряндр", "НеДанилков", 1314, 678635, DateTime.Parse "17.04.2022")
    Console.WriteLine(compare licence2 licence1)
    Console.WriteLine(licence1 <> licence2)
    let lic = inputDriversLicense()
    

    0