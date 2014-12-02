﻿namespace Katabase

module RomanNumerals =
    
    let patternSet = [("I","V","X"); ("X","L","C"); ("C","D","M")]

    let replace fnd rpl (str:string) =
        str.Replace((fnd |> String.concat ""), (rpl |> String.concat ""))

    let toRoman arabicNumeral =
        
        let supressInvalidRange n =
            match n with
            | n when n <= 0     -> None
            | n when n >= 4000  -> None
            | _                 -> Some n

        let tally n =
            match n with
            | Some n  -> String.replicate n "I"
            | None    -> ""

        let replaceFor patterns (str:string) =
            let replaceForPattern (i, v, x) (str:string) =
                str
                |> replace [i;i;i;i;i]  [v]
                |> replace [i;i;i;i]    [i;v]
                |> replace [v;v]        [x]
                |> replace [v;i;v]      [i;x]
            patterns |> List.fold(fun s p -> replaceForPattern p s) str

        arabicNumeral
        |> supressInvalidRange
        |> tally
        |> replaceFor patternSet
    
    let toArabic romanNumeral =
        
        let garbage str =
            str
            |> replace ["I"] [""]  |> replace ["V"] [""]  |> replace ["X"] [""]  
            |> replace ["L"] [""]  |> replace ["C"] [""]  |> replace ["D"] [""]
            |> replace ["M"] [""]
            |> String.length
        
        let suppressInvalidChars str =
            match garbage str with
            | 0  -> str
            | _  -> ""
            
        let replaceFor patterns (str:string) =
            let replaceForPattern (i, v, x) (str:string) =
                str
                |> replace [i;x]    [v;i;v]
                |> replace [x]      [v;v]
                |> replace [i;v]    [i;i;i;i]
                |> replace [v]      [i;i;i;i;i]
            patterns |> List.rev |> List.fold(fun s p -> replaceForPattern p s) str
        
        romanNumeral
        |> suppressInvalidChars
        |> replaceFor patternSet
        |> String.length
        