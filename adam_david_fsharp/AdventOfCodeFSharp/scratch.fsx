#r @"..\packages\NUnit.3.8.1\lib\net45\nunit.framework.dll"
#r @"..\packages\FsUnit.3.0.0\lib\net45\FsUnit.NUnit.dll"

#load "Day_03_pt2.fs"

open Day_03_pt2

let calulateArraySize (v:int) =

  let x = System.Math.Ceiling( System.Math.Sqrt (v |> double)) |> int

  match x % 2 with
  | 0 -> x + 1
  | 1 -> x
  | _ -> failwith "This should happen"
  
let makeSquareArray size = Array2D.zeroCreate<int> size size

let problemNumber = 361527
//let problemNumber = 20

let arraySize = problemNumber |> calulateArraySize 

let initialState = 
  {
    currentDirection = Direction.E
    spiralWidth = 2
    currentWalkDistance = 0
    position = {x = 0; y = 0 }
    currentNumber = 1
  }
  |> move

let getCellTotal x y (board:int[,]) =
  seq{
    for x in -1..1 do
      for y in -1..1 do
        yield (x,y)
  }
  |> Seq.map (fun (a,b) -> (a+x), (b+y))
  |> Seq.filter (fun (x,y) -> (x >= 0) && (y >= 0) && (x <= board.GetUpperBound(0)) && (y <= board.GetUpperBound(1) ) ) 
  |> Seq.map(fun (x,y) -> board.[x,y])
  |> Seq.sum


// https://stackoverflow.com/a/24967736/29521
let takeUntil pred s =
  let state = ref true
  Seq.takeWhile (fun el ->
    let ret= !state
    state := not <| pred el
    ret
    ) s

let board =  arraySize |> makeSquareArray 
board.[arraySize/2,arraySize/2] <- 1

Seq.unfold (fun state -> 
  let newState = state |> move 
  Some(state, newState) // Return the 'previous' state so the first state is the initial state
) initialState
|> Seq.takeWhile (fun state -> state.currentNumber <= problemNumber)
|> Seq.map (fun state -> 
    let boardX = state.position.x + (arraySize/2)
    let boardY = state.position.y + (arraySize/2)
    let cellTotal = getCellTotal boardX boardY board
    board.[boardX, boardY] <- cellTotal
    cellTotal)
|> Seq.find(fun cellTotal -> cellTotal > problemNumber)
//|> Seq.last
|> printfn "Answer: %d"
//board