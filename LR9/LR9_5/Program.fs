open System.Windows.Forms

let Form = new Form(Width = 600, Height = 100, Text = "LR9_5")

let ProgressBar1 = new ProgressBar(Dock = DockStyle.Bottom)
let TextBox1 = new TextBox (Width = 300, Height=100, Top=20, Left = 150, MaxLength = 50)

let changes _ = ProgressBar1.Value <- TextBox1.TextLength*2
TextBox1.TextChanged.Add(changes)

Form.Controls.Add(TextBox1)
Form.Controls.Add(ProgressBar1)

[<EntryPoint>]
let main argv =
    do Application.Run(Form)
    0