module Day_03_pt2

open NUnit.Framework
open FsUnit

type Direction = N|W|S|E

type Position = {  x: int;  y: int }

type State = {
  currentDirection : Direction;
  spiralWidth: int;
  currentWalkDistance: int;
  position: Position;
  currentNumber: int
}

let walk (state:State) =
  match state.currentDirection with
  | Direction.E -> {state with State.position = {state.position with x = state.position.x + 1};}
  | Direction.N -> {state with State.position = {state.position with y = state.position.y - 1};}
  | Direction.W -> {state with State.position = {state.position with x = state.position.x - 1};}
  | Direction.S -> {state with State.position = {state.position with y = state.position.y + 1};}
  |> (fun state -> {state with State.currentNumber = state.currentNumber + 1; State.currentWalkDistance = state.currentWalkDistance + 1})


let changeDirection (state:State) =
  match state.currentDirection with
  | Direction.E -> {state with State.currentDirection = Direction.N; State.currentWalkDistance = 0}
  | Direction.N -> {state with State.currentDirection = Direction.W; State.currentWalkDistance = 0; State.spiralWidth = state.spiralWidth + 1}
  | Direction.W -> {state with State.currentDirection = Direction.S; State.currentWalkDistance = 0}
  | Direction.S -> {state with State.currentDirection = Direction.E; State.currentWalkDistance = 0; State.spiralWidth = state.spiralWidth + 1}

let applyDirection currentState = 
  if currentState.currentWalkDistance = currentState.spiralWidth - 1 then currentState |> changeDirection
  else currentState 

let move (currentState:State) : (State) = 
  currentState 
  |> applyDirection
  |> walk

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

let getCellTotal (x,y) (board:int[,]) =
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

let solver problemNumber = 
  let board =  arraySize |> makeSquareArray 
  board.[arraySize/2,arraySize/2] <- 1

  let mapToBoardCoors state =
    let boardX = state.position.x + (arraySize/2)
    let boardY = state.position.y + (arraySize/2)
    (boardX, boardY)

  Seq.unfold (fun state -> 
    let newState = state |> move 
    Some(state, newState) // Return the 'previous' state so the first state is the initial state
  ) initialState
  |> Seq.takeWhile (fun state -> state.currentNumber <= problemNumber)
  |> Seq.map (fun state -> 
      let boardCoords = state |> mapToBoardCoors
      let cellTotal = getCellTotal  boardCoords board
      board.[boardCoords |> fst, boardCoords |> snd] <- cellTotal
      cellTotal)
  |> Seq.find(fun cellTotal -> cellTotal > problemNumber)
   
[<Test>]
let ``20``()=
  20 |> solver |> should equal 23

[<Test>]
let realTest() = 
  361527
  |> solver
  |> (printfn "Ans is: %d")
