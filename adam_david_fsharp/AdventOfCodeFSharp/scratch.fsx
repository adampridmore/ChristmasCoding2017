#r @"..\packages\NUnit.3.8.1\lib\net45\nunit.framework.dll"
#r @"..\packages\FsUnit.3.0.0\lib\net45\FsUnit.NUnit.dll"

//#load "Day_03_pt2.fs"

open FsUnit

let defaultDelimiters = [|",";"\n";System.Environment.NewLine|]

let split (delimiters:string array) (text:string) = 
    text.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries)

let charArrayToString (ca:seq<char>) = 
  new System.String(ca |> Seq.toArray)

let isValid passphrase = 
  passphrase
  |> split [|" "|]
  |> Seq.map (fun text -> text.ToCharArray() |> Seq.sort |> charArrayToString)
  |> Seq.groupBy(id)
  |> Seq.exists(fun (k,v) -> v |> Seq.length > 1)
  |> not

"abcde fghij"
|> isValid

"abcde xyz ecdab"
|> isValid
