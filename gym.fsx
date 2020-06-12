#r "nuget: FSharp.Plotly"
#r "nuget: FSharp.Data"

open FSharp.Plotly
open FSharp.Data
open System

let parseInt =
    function
    | ""
    | null -> None
    | str -> Some(int str)

let parseDouble =
    function
    | ""
    | null -> None
    | str -> Some(double str)

type Training =
    { Date: DateTime
      Activity: string
      Series: int option
      Weight: double option
      RepetitionNumber: int option }


let readCsv (path: string) = FSharp.Data.CsvFile.Load(path, ";")

let parse (row: FSharp.Data.CsvRow) =
    let date =
        sprintf "%s %s" row.["Data"] row.["Czas"]
        |> DateTime.Parse

    { Date = date
      Activity = row.["Ćwiczenie"]
      Series = row.["Seria"] |> parseInt
      Weight = row.["Waga"] |> parseDouble
      RepetitionNumber = row.["Powt."] |> parseInt }


let csv =
    readCsv "E:\personal_projects\my-gym-statistics\GymRun.csv"

let data = csv.Rows |> Seq.map (parse)

//Chart.Pie(values,labels) |> Chart.Show

printfn "%A" (data)
