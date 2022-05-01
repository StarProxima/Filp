open System.Windows
open System.Windows.Controls
open System.Windows.Markup
open System

let getWindow() =
    let xaml = "
        <Window
        	xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
        	xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml' Title='LR9_6' Height='300' Width='600'>
        	<Grid>
        		<Grid.ColumnDefinitions>
        			<ColumnDefinition Width='320*' />
        		</Grid.ColumnDefinitions>
                <Grid.RowDefinitions>
                    <RowDefinition Height='140*' />
                    <RowDefinition Height='140*' />
                </Grid.RowDefinitions>
                <ProgressBar Height ='30' HorizontalAlignment = 'Center' Margin = '20,60,0,0'
                            Name = 'ProgressBar1' VerticalAlignment = 'Top' Width = '300' />
                <TextBox Height='23' HorizontalAlignment = 'Center' Margin='20,30,0,0'
                 Name='TextBox1' VerticalAlignment = 'Top' Width='300' MaxLength = '50'/>       		
        	</Grid>
        </Window> "

    let window = XamlReader.Parse(xaml) :?> Window
    let TextBox1 = window.FindName("TextBox1") :?> TextBox 
    let ProgressBar1 = window.FindName ("ProgressBar1"):?> ProgressBar

    let changes _ = ProgressBar1.Value <- float(TextBox1.Text.Length*2)
    TextBox1.TextChanged.Add(changes)

    window


[<EntryPoint>]
[<STAThread>] 
let main argv =
    (new Application()).Run (getWindow()) |> ignore
    0