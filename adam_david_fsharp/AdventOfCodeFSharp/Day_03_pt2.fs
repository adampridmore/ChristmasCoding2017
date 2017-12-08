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

let solver problemNumber = 
  let initialState = {
    currentDirection = Direction.E
    spiralWidth = 2
    currentWalkDistance = 0
    position = {x = 0; y = 0 }
    currentNumber = 1
  } 

  let last =
    Seq.unfold (fun state -> 
      let newState = state |> move 
      Some(state, newState) // Return the 'previous' state so the first state is the initial state
    ) initialState
    |> Seq.takeWhile (fun state -> state.currentNumber <= problemNumber)
    |> Seq.last

  System.Math.Abs(last.position.x) + System.Math.Abs(last.position.y)
   
[<Test>]
let ``1``()=
  1 |> solver |> should equal 0

[<Test>]
let ``12``()=
  12 |> solver |> should equal 3

[<Test>]
let ``23``()=
  23 |> solver |> should equal 2

[<Test>]
let ``1024``()=
  1024 |> solver |> should equal 31

[<Test>]
let realTest() = 
  361527
  |> solver
  |> (printfn "Ans is: %d")
