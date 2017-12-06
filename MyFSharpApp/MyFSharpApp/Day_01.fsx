
let rowChecksum (x: string) =
  let values = x.Split(' ') |> Seq.map (string >> int)

  (values |> Seq.max) - (values |> Seq.min)


let x = "5 1 9 5"


let split (text:string) = 
  let delimiters = [|",";"\n";System.Environment.NewLine|]
  text.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries)

let text = "5 1 9 5
7 5 3
2 4 6 8"

text 
|> split
|> Seq.map rowChecksum
|> Seq.sum

