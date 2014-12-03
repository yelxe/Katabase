namespace Katabase

module BowlingGame =

    type Bonus =
        | Strike
        | Spare
        | NoBonus

    type Game=(int*int)list

    let NewGame = []

    let playFrame (r1, r2) = List.append [(r1, r2)]
    
    let score (game:Game) =
        
        
        let scoreFrame i (a, b) =
            a + b


//            match snd (frameResult frame1) with
//            | Strike  -> match snd (frameResult frame2) with
//                           | Strike  -> both frame1 + fst frame2 + fst frame3
//                           | _       -> both frame1 + both frame2
//            | Spare   -> both frame1 + fst frame2
//            | _       -> both frame1

        game 
        |> List.mapi scoreFrame
        |> List.sum

        //frames |> List.iteri(fun a b c -> scoreFrame frames[i] frames.[i+1] frames.[i+2]) |> List.sum
