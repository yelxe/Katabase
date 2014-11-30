namespace Katabase.Tests

open NUnit.Framework
open FsUnit
open Katabase.RomanNumerals

module ``RomanNumerals Tests`` =
    
    module ``toRoman`` =
        
//        [<TestCaseSource("convertDictionary")>]
//        let ``Should convert correctly`` (a, r) =
//            toRoman a |> should equal r
//
//        let convertDictionary () =
//            [
//                [|(1, "I")|];
//                [|(2, "II")|]
//            ]


        
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
        
        [<Test>]
        let ``11 to 20`` () =
            toRoman 11 |> should equal "XI"
            toRoman 12 |> should equal "XII"
            toRoman 13 |> should equal "XIII"
            toRoman 14 |> should equal "XIV"
            toRoman 15 |> should equal "XV"
            toRoman 16 |> should equal "XVI"
            toRoman 17 |> should equal "XVII"
            toRoman 18 |> should equal "XVIII"
            toRoman 19 |> should equal "XIX"
            toRoman 20 |> should equal "XX"
        
        [<Test>]
        let ``High Numbers`` () =
            toRoman 4000 |> should equal "M^V"
            toRoman 6500 |> should equal "^VMD"

        [<Test>]
        let ``Other Numbers`` () =
            toRoman   99 |> should equal "XCIX"
            toRoman 1337 |> should equal "MCCCXXXVII"
            toRoman 1975 |> should equal "MCMLXXV"
            toRoman 1999 |> should equal "MCMXCIX"
            toRoman 2014 |> should equal "MMXIV"

        [<Test>]
        let ``Out of Range Numbers`` () =
            toRoman     0 |> should equal ""
            toRoman 40000 |> should equal ""
        