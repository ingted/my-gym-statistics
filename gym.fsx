#r "nuget: FSharp.Plotly"
#r "nuget: FSharp.Data"

open FSharp.Plotly
open FSharp.Data
open System 

type Training = { Date: DateTime; Activity: string; Series: int; Weight: double; RepetitionNumber: int }

let readCsv (path: string) =
    FSharp.Data.CsvFile.Load path

let parse(row: FSharp.Data.CsvRow) = 
    row.Columns |> Array.head


let csv = readCsv "E:\personal_projects\my-gym-statistics\GymRun.csv"

let data = csv.Rows |> Seq.map(parse)

//Chart.Pie(values,labels) |> Chart.Show

printfn "%A" data
