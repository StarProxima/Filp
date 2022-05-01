open System
open System.Windows.Forms
open System.Drawing

let arr1317 n =
    let rec arr1317Internal (arr: int[]) cand = 
        if arr.Length = n then
            arr
        else
            let newArr = if (cand % 13 = 0|| cand % 17 = 0) then Array.append arr [|cand|] else arr
            let newCand = cand+1
            arr1317Internal newArr newCand
    Array.sort (arr1317Internal [||] 1)

Application.EnableVisualStyles()

let form = new Form(Text="LR9_8",Height=300,Width=550)

let label1 = new Label (Text="Напишите программу, заносящую в массив первые 100 натуральных чисел, делящихся на 13 или на 17, и печатающую его.", Left = 10, Top=10, Width=400, Height=30)

let TextBox = new TextBox(Text="",Left = 10,Top = 50,Width=500,Height=100,Multiline=true)  

let button = new Button()
button.Text <- "Посчитать"
button.Location<-new Point(400,10) 
button.Click.AddHandler(fun _ _ ->
    let array = arr1317 100 
    (TextBox.Text <- (array |> Seq.map string |> String.concat ", ")) |> ignore) 

form.Controls.Add(label1)
form.Controls.Add(button)
form.Controls.Add(TextBox)

Application.Run(form)