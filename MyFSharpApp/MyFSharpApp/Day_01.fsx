let problemNumber = 361527
//let problemNumber = 19

let calulateArraySize (v:int) =

  let x = System.Math.Ceiling( System.Math.Sqrt (v |> double)) |> int

  match x % 2 with
  | 0 -> x + 1
  | 1 -> x
  | _ -> failwith "This should happen"
  
let makeSquareArray size =
  Array2D.zeroCreate<int> size size

let arraySize = problemNumber |> calulateArraySize 
  
//let board = 
//  arraySize
//  |> makeSquareArray 

type Direction = N|W|S|E
type Position = {
  x: int;  y: int
}
type State = {
  currentDirection : Direction;
  spiralWidth: int;
  currentWalkDistance: int;
  position: Position;
  currentNumber: int
}

let drawOnBoard (board: int[,]) (state: State) = board.[state.position.x, state.position.y] <- state.currentNumber

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

let move board (currentState:State) : (State) = 
  drawOnBoard board currentState // Mutate! Shhh

  currentState 
  |> applyDirection
  |> walk


let initialState = {
  currentDirection = Direction.E
  spiralWidth = 2
  currentWalkDistance = 0
  position = {x = arraySize / 2; y = arraySize / 2 }
  currentNumber = 1
} 

//initialState |> move |> move |> move|> move |> move |> move
//board

//seq{1..15} 
//|> Seq.fold (fun acc (nm,x) -> acc+x) 0 

//let ans = 
//  {0..problemNumber} 
//  |> Seq.fold (fun state _ -> 
//      let newState = (state |> move)
//      newState
//    ) 
//    initialState
//
//let xDiff = System.Math.Abs(ans.position.x - (arraySize /2) ) - 1
//let yDiff = System.Math.Abs(ans.position.y - (arraySize / 2) ) - 1
//printfn "Ans is: %d" (xDiff+yDiff)

let board = 
  arraySize
  |> makeSquareArray 

let last =
  Seq.unfold (fun state -> 
    let newState = state |> move board ; 
    Some(newState, newState) 
  ) initialState
  //|> Seq.takeWhile (fun state -> state.currentNumber <= problemNumber)
  |> Seq.take (problemNumber + 1)
  |> Seq.last

let xDiff = System.Math.Abs(last.position.x - (arraySize /2) ) - 1
let yDiff = System.Math.Abs(last.position.y - (arraySize / 2) ) - 1
printfn "Ans is: %d" (xDiff+yDiff)



//ans
//
//val it : State = {currentDirection = N;
//                  spiralWidth = 602;
//                  currentWalkDistance = 327;
//                  position = {x = 602;
//                              y = 274;};
//                  currentNumber = 361529;}


//board |> Seq.find(fun )

//printfn "It's 326"