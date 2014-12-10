namespace Katabase

module BowlingGame =

    type Frame = (int*int)
    type Game = (Frame)list
    
    let (|Strike|Spare|Lame|) (a, b) = 
        match a + b with
        | 10 when a = 10  -> Strike
        | 10              -> Spare
        | _               -> Lame

    let NewGame = []

    let playFrame frame game = List.append game [frame]
    
    let score (game:Game) =
                
        let rec scoreFrames i frames  =
            
            let next = scoreFrames (i + 1)
            
            match i, frames with
            | 10, _                           ->  0
            | _, []                           ->  0
            | _, Strike::Strike::(a,b)::rest  -> 20  +  a        +  next ((10,0)::(a,b)::rest)
            | _, Strike::(a,b)::rest          -> 10  +  a  +  b  +  next ((a,b)::rest)
            | _, Spare::(a,b)::rest           -> 10  +  a        +  next ((a,b)::rest)
            | _, (a,b)::rest                  ->  a  +  b        +  next rest

        game
        |> scoreFrames 0
