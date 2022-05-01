open System
open System.Windows.Forms
open System.Drawing


let form = new Form(Width=502, Height=350,Text = "LR9_9")

let button1 = new Button(Left=10, Top=10, Text="Отзеркалить", Width=100,Height=30)
let label1 = new Label(Text = "Введите список:", Left=150,Top=10,Width=100,Height=20)
let TextBox1 = new TextBox(Left=150,Width=200,Top=30,Height=25)
let label2 = new Label(Text = "Отзеркаленный список:", Left=150,Top=60,Width=200,Height=20)
let TextBox2 = new TextBox(Left=150,Width=200,Top=80,Height=25)

form.Controls.Add(TextBox1);
form.Controls.Add(TextBox2);
form.Controls.Add(label1);
form.Controls.Add(label2);
form.Controls.Add(button1);

Application.EnableVisualStyles()

let strToList (str:string)  =
    str.Replace(",","").Split(' ') |> Array.toList

button1.Click.AddHandler(fun _ _ ->
    let list1 = strToList TextBox1.Text
    let list2= List.rev list1
    (TextBox2.Text <- (list2 |> Seq.map string |> String.concat ", ")) |> ignore)            

Application.Run(form)