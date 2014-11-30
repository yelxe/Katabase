namespace Katabase

module RomanNumerals =
    
    let toRoman arabicNumeral =
        
        let patternSets = [("I","V","X"); ("X","L","C"); ("C","D","M"); ("M","^V","^X")]

        let supressInvalidRange n =
            match n with
            | n when n <= 0     -> None
            | n when n >= 40000 -> None
            | _                 -> Some n

        let tally n =
            match n with
            | Some n    -> String.replicate n "I"
            | None      -> ""

        let replace fnd rpl (str:string) =
            str.Replace((fnd |> String.concat ""), (rpl |> String.concat ""))
        
        let replaceFor (i, v, x) (str:string) =
            str
            |> replace [i;i;i;i;i]  [v]
            |> replace [i;i;i;i]    [i;v]
            |> replace [v;v]        [x]
            |> replace [v;i;v]      [i;x]

        arabicNumeral
        |> supressInvalidRange
        |> tally
        |> replaceFor patternSets.[0]
        |> replaceFor patternSets.[1]
        |> replaceFor patternSets.[2]
        |> replaceFor patternSets.[3]
