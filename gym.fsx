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
    | str -> Some(Double.Parse str)

type Training =
    { Date: DateTime
      Activity: string
      Series: int option
      Weight: double option
      RepetitionNumber: int option }


let readCsv (path: string) = FSharp.Data.CsvFile.Load(path, ";")

let parse (row: FSharp.Data.CsvRow) =
    match row.["Data"], row.["Czas"] with
    | "Data", "Czas"
    | "", ""
    | null, null -> None
    | date, time ->
        let dateTime =
            sprintf "%s %s" date time |> DateTime.Parse

        Some
            ({ Date = dateTime
               Activity = row.["Ćwiczenie"]
               Series = row.["Seria"] |> parseInt
               Weight = row.["Waga"] |> parseDouble
               RepetitionNumber = row.["Powt."] |> parseInt })


let csv =
    readCsv "E:\personal_projects\my-gym-statistics\GymRun.csv"

let data =
    csv.Rows |> Seq.map (parse) |> Seq.choose id

let activities =
    data
    |> Seq.groupBy (fun x -> x.Activity)
    |> Seq.map (fun (key, activ) ->
        {| Label = key
           Count = activ |> Seq.length |})
    |> Seq.sortByDescending(fun x -> x.Count)
    |> Seq.take 5

let labels =
    activities
    |> Seq.map (fun x -> x.Label)

let values =
    activities
    |> Seq.map (fun x -> x.Count |> string)

Chart.Pie(values, labels) |> Chart.Show
