open System
open System.Drawing
open System.Windows.Forms

let form = new Form(
    Width= 600, Height = 200,
    Visible = true,
    Text = "LR9_7"
    
)

let labelX = new Label(Text="X:", Left=10, Top=10, Width=15, Height=20)
let textBox1 = new TextBox(Text="0", Left=10, Top=30, Width=55, Height=20)

let labelAns = new Label (Text="0",Left = 200,Top=10,Width=400,Height=50)
let button = new  Button (Text = "Посчитать", Left=100,Top=10,Width=80,Height=50)



form.Controls.Add(labelAns);
form.Controls.Add(button);
form.Controls.Add(labelX);

form.Controls.Add(textBox1);

let count _ = 
    let tuple3Ans(x,y,z) =
        (Math.Cos(x),
         Math.Sin(y),
         Math.Tan(z))
    
    let tuple3 = (float(textBox1.Text),float(textBox1.Text),float(textBox1.Text))

    labelAns.Text <- string (tuple3Ans tuple3)

let _ = button.Click.Add(count)     

do Application.Run(form)