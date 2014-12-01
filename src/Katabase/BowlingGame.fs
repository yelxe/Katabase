namespace Katabase

module BowlingGame =
    
    let frame (first, second) (score, spares) =
        
        let bonus =
            match spares with
            | 0  -> 0
            | 1  -> first
            | _  -> first + second

        let earnedSpares =
            match (first, second) with
            | (10, 0)                 -> 2
            | (f, s) when f + s = 10  -> 1
            | _                       -> 0

        let usedSpares =
            match (first, second) with
            | (10, 0)  -> 1
            | _        -> 2
            
        let unusedSpares =
            match spares - usedSpares with
            | n when n < 0  -> 0
            | a             -> a

        (score + first + second + bonus, unusedSpares + earnedSpares)
