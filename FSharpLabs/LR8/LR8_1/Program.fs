open System

type IPrint = interface
    abstract member Print: unit -> unit
    end

[<AbstractClass>]
type Figure() =
    abstract member GetArea: unit -> double

type Rectangle(width: double, height: double) =
    inherit Figure()
    
    let mutable width = width
    let mutable height = height
    
    member this.Width
        with get() = width
        and set(value) = width <- value

    member this.Height
        with get() = height
        and set(value) = height <- value

    override this.GetArea() = (this.Width * this.Height)
    override this.ToString() = sprintf "Rectangle{Width=%f, Height=%f, Area=%f}" this.Width this.Height (this.GetArea())

    interface IPrint with
        member this.Print() = Console.WriteLine (this.ToString())

type Square(side: double) =
    inherit Rectangle(side, side)
    override this.ToString() = sprintf "Square{Side=%f, Area=%f}" this.Width (this.GetArea())

    interface IPrint with
        member this.Print() = Console.WriteLine (this.ToString())

type Circle(radius: double) =
    inherit Figure()
    
    let mutable radius = radius
    
    member this.Radius
        with get() = radius
        and set(value) = radius <- value

    override this.GetArea() = (Math.PI * this.Radius * this.Radius)

    override this.ToString() = sprintf "Circle{Radius=%f, Area=%f}" this.Radius (this.GetArea())

    interface IPrint with
        member this.Print() = Console.WriteLine (this.ToString())

type GeometricFigure = 
    | GeometricRectangle of double * double
    | GeometricSquare of double
    | GeometricCircle of double

let CalculateArea (figure: GeometricFigure) =
    match figure with
    | GeometricRectangle(w,h) -> w * h
    | GeometricSquare(s) -> s * s
    | GeometricCircle(r) -> Math.PI * r * r

[<EntryPoint>]
let main argv =
    let rectangle = Rectangle(3.5, 7.0)
    printfn "Rectangle area: %f" (rectangle.GetArea())

    let circle = Circle(5.0)

    printfn "Circle area: %f" (circle.GetArea())
    
    let geometricSquare = GeometricSquare(2.875)
    printfn "Square area: %f" (CalculateArea geometricSquare)

    0