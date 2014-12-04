namespace Katabase.Tests

open NUnit.Framework
open FsUnit
open Katabase.RomanNumerals

module ``RomanNumerals Tests `` =
    
    module `` toRoman`` =
        
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
        let ``Other Numbers`` () =
            toRoman 1337 |> should equal "MCCCXXXVII"
            toRoman 1975 |> should equal "MCMLXXV"
            toRoman 1999 |> should equal "MCMXCIX"
            toRoman 2014 |> should equal "MMXIV"

        [<Test>]
        let ``Out of Range Numbers`` () =
            toRoman    0 |> should equal ""
            toRoman 4000 |> should equal ""
    
    module `` toArabic`` =
        
        [<Test>]
        let ``I to X`` () =
            toArabic "I"    |> should equal  1
            toArabic "II"   |> should equal  2
            toArabic "III"  |> should equal  3
            toArabic "IV"   |> should equal  4
            toArabic "V"    |> should equal  5
            toArabic "VI"   |> should equal  6
            toArabic "VII"  |> should equal  7
            toArabic "VIII" |> should equal  8
            toArabic "IX"   |> should equal  9
            toArabic "X"    |> should equal 10
        
        [<Test>]
        let ``Other Numerals`` () =
            toArabic "MCCCXXXVII" |> should equal 1337
            toArabic "MCMLXXV"    |> should equal 1975
            toArabic "MCMXCIX"    |> should equal 1999
            toArabic "MMXIV"      |> should equal 2014

        [<Test>]
        let ``Invalid Numerals`` () =
            toArabic "A"    |> should equal 0
            toArabic "VA"   |> should equal 0
