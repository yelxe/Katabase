namespace Katabase

module RomanNumerals =
    
    let I = "I"
    let V = "V"
    let X = "X"
    let L = "L"
    let C = "C"
    let D = "D"
    let M = "M"
    let I' = "^I"
    let V' = "^V"
    let X' = "^X"

    let toRoman arabicNumeral =
        
        let sets = [(I,V,X); (X,L,C); (C,D,M); (M,V',X')]

        let tally x =
            String.replicate x I

        let replace (fnd) (rpl) (str:string) =
            str.Replace((fnd |> String.concat ""), (rpl |> String.concat ""))
        
        let replaceFor (a, b, c) (str:string) =
            str
            |> replace [a;a;a;a;a]  [b]
            |> replace [a;a;a;a]    [a;b]
            |> replace [b;b]        [c]
            |> replace [b;a;b]      [a;c]

        arabicNumeral
        |> tally
        |> replaceFor sets.[0]
        |> replaceFor sets.[1]
        |> replaceFor sets.[2]
        |> replaceFor sets.[3]

    let toArabic romanNumeral =
        0
