

let x = "1212"

let values = x.ToCharArray() |> Seq.map (string >> int) |> Seq.toList

let getOtherValue i =
  (i + (values.Length/2)) % values.Length
  
values
|> Seq.mapi (fun i v -> (i,v) ) 
|> Seq.filter(fun (i, v) -> values.[i |> getOtherValue] = v)
|> Seq.map snd
|> Seq.sum

