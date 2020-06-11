#r "nuget: FSharp.Plotly"
#r "nuget: FSharp.Data"

open FSharp.Plotly
open FSharp.Data
open System 

type Training = { Date: DateTime; Activity: string; Series: int; Weight: double; RepetitionNumber: int }

let readCsv (path: string) =
    try
        let data = FSharp.Data.CsvFile.Load path
        data |> Some
    with ex -> 
        printfn "%A" ex
        None

let parse(row: CsvRow) = 2

let values =[66; 34]
let labels =["How much I like this!";"Same but in orange"]
let csv = readCsv "E:\personal_projects\my-gym-statistics\GymRun.csv"

//Chart.Pie(values,labels) |> Chart.Show

printfn "%A" csv
