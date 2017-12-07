module Solutions

let shiftForward n list =
    (list |> List.skip n)@(list |> List.take n)

let sumRepeats position (input:string)  = 
    let inputList = input |> List.ofSeq

    inputList
    |> List.zip (inputList |> shiftForward position)
    |> List.sumBy( fun (current, next) -> 
        if current = next then current.ToString() |> int else 0)

let sumFollowingRepeats (input:string) = 
    input |> sumRepeats 1

let sumHalfwayRepeats (input:string) = 
    let positionToCheck = (input |> Seq.length) / 2
    input |> sumRepeats positionToCheck
    