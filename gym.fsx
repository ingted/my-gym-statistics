#r "nuget: FSharp.Plotly"
open FSharp.Plotly
let values =[66; 34]
let labels =["How much I like this!";"Same but in orange"]
Chart.Pie(values,labels) |> Chart.Show