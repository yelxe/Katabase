namespace Katabase

module Yahtzee =
    
    type Roll = (int*int*int*int*int)

    let toList (roll:Roll) =
        let r1, r2, r3, r4, r5 = roll
        [r1;r2;r3;r4;r5]

    let toSeq (roll:Roll) =
        let r1, r2, r3, r4, r5 = roll
        seq [r1;r2;r3;r4;r5]

    let scoreNumber n (roll:Roll) =
        roll
        |> toSeq
        |> Seq.filter((=) n)
        |> Seq.sum
        
    let countNumber n (roll:Roll) =
        roll
        |> toSeq
        |> Seq.filter((=) n)
        |> Seq.length

//    let scoreThreeOfKind (roll:Roll) =
//        roll
//        |> toList
