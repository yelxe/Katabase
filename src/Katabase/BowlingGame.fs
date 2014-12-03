namespace Katabase

module BowlingGame =

    type Game = (int*int)list

    let NewGame = []

    let playFrame frame game = List.append game [frame]
    
    let score (game:Game) =
                
        let scoreNextRoll i = 
            game.[i + 1] |> fst

        let scoreFrame i (a, b) =
            match a + b with
            | 10  -> a + b + scoreNextRoll i
            | _   -> a + b

        game 
        |> List.mapi scoreFrame
        |> List.sum
