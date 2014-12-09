namespace Katabase

module BowlingGame =

    type Frame = (int*int)
    type Game = (Frame)list
    
    let (|Strike|Spare|Lame|) (a, b) = 
           match a + b with
           | 10 when a = 10 -> Strike
           | 10 -> Spare
           | _  -> Lame

    let NewGame = []

    let playFrame frame game = List.append game [frame]
    
    let score (game:Game) =
                
        let scoreNextRoll = function
        | (a,_)::_  -> a
        | []        -> 0

        let scoreNextTwoRolls = function
        | Strike::(c,_)::_  -> 10 + c
        | (a,b)::_          -> a + b
        | []                -> 0

        let rec scoreFrames i frames  =
            match i, frames with
            | 10, _            -> 0
            | _, []            -> 0
            | _, Strike::rest  -> 10 + scoreNextTwoRolls rest + scoreFrames (i + 1) rest
            | _, Spare::rest   -> 10 + scoreNextRoll rest + scoreFrames (i + 1) rest
            | _, (a,b)::rest   -> a + b + scoreFrames (i + 1) rest

        game
        |> scoreFrames 0
