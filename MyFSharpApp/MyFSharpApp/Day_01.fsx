

let x = "1122"

x.ToCharArray() 
|> Seq.map (string >> int)
|> Seq.pairwise
|> Seq.filter (fun (a,b) -> a = b) 
|> Seq.map fst
|> Seq.sum
