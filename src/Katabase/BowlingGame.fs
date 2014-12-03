namespace Katabase

module BowlingGame =

    type Frame = (int*int)
    type Game = (Frame)list
    
    let NewGame = []

    let playFrame frame game = List.append game [frame]
    
    let score (game:Game) =
                
        let scoreNextRoll i = 
            game.[i + 1] |> fst

        let scoreNextTwoRolls i =
            match fst game.[i + 1] with
            | 10  -> fst game.[i + 1] + fst game.[i + 2]
            | _   -> fst game.[i + 1] + snd game.[i + 1]

        let scoreFrame i (a, b) =
            match a + b with
            | 10 when a = 10  -> 10 + scoreNextTwoRolls i
            | 10              -> 10 + scoreNextRoll i
            | n               -> n

        game
        |> Seq.take 10
        |> List.ofSeq
        |> List.mapi scoreFrame
        |> List.sum
