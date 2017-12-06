//let x = "5 9 2 8"
//let x = "9 4 7 3"
let x = "3 8 6 5"


let split (text:string) = 
  let delimiters = [|",";"\n";System.Environment.NewLine|]
  text.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries)

let rowChecksum(text:string) = 

  let values = text.Split(' ') |> Seq.map (string >> int)

  let OrderedTuple (a,b) = 
    if a > b then (a,b)
    else (b,a)
  
  let processThing (values:seq<int>, value:int) =
    values 
    |> Seq.map(fun x -> OrderedTuple(x,value))
    |> Seq.map(fun (a,b) -> (a / b), a % b = 0)
    |> Seq.filter snd
    |> Seq.map fst
    |> Seq.tryHead

  values 
  |> Seq.mapi (fun i v -> values |> Seq.skip (i + 1) |> (fun x -> (x, v)))
  |> Seq.choose processThing
  |> Seq.head

