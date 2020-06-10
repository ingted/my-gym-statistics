#r "nuget: FSharp.Plotly"
#r "nuget: FSharp.Data"

open FSharp.Plotly
open FSharp.Data

let readCsv (path: string) =
    try
        let data = FSharp.Data.CsvFile.Load path
        data |> Some
    with ex -> 
        printfn "%A" ex
        None

let values =[66; 34]
let labels =["How much I like this!";"Same but in orange"]
let csv = readCsv "E:\personal_projects\my-gym-statistics\GymRun.csv"

//Chart.Pie(values,labels) |> Chart.Show

printfn "%A" csv
