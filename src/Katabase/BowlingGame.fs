namespace Katabase

module BowlingGame =

    type Frame = (int*int)
    type Game = (Frame)list
    
    let NewGame = []

    let playFrame frame game = List.append game [frame]
    
    let score (game:Game) =
                
        let scoreNextRoll = function
        | (a,_)::_  -> a
        | []        -> 0

        let scoreNextTwoRolls = function
        | (10,0)::(c,_)::_  -> 10 + c
        | (a,b)::_          -> a + b
        | []                -> 0

        let rec scoreFrames i frames  =
            match i, frames with
            | 10, _                           -> 0
            | _, []                           -> 0
            | _, (10,0)::rest                 -> 10 + scoreNextTwoRolls rest + scoreFrames (i + 1) rest
            | _, (a,b)::rest when a + b = 10  -> 10 + scoreNextRoll rest + scoreFrames (i + 1) rest
            | _, (a,b)::rest                  -> a + b + scoreFrames (i + 1) rest

        game
        |> scoreFrames 0
