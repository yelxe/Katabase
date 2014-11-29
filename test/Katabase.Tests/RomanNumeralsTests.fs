namespace Katabase.Tests

open NUnit.Framework
open FsUnit
open Katabase.RomanNumerals

module ``RomanNumerals Tests`` =
    
    module ``toRoman`` =
        
        [<Test>]
        let ``1 to 10`` () =
            toRoman  1 |> should equal "I"
            toRoman  2 |> should equal "II"
            toRoman  3 |> should equal "III"
            toRoman  4 |> should equal "IV"
            toRoman  5 |> should equal "V"
            toRoman  6 |> should equal "VI"
            toRoman  7 |> should equal "VII"
            toRoman  8 |> should equal "VIII"
            toRoman  9 |> should equal "IX"
            toRoman 10 |> should equal "X"
