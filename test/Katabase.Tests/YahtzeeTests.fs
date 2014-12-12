namespace Katabase.Tests

open NUnit.Framework
open FsUnit
open Katabase.Yahtzee

module ``Yahtzee Tests `` =
    
    module `` scoreForNumber `` =
        
        [<Test>]
        let ``Score for 1 thru 6`` () =
            let cases =
                [
                    (1, (1,2,3,4,5),  1); (1, (2,1,4,6,1),  2); (1, (1,1,1,1,1),  5);
                    (2, (1,2,3,4,5),  2); (2, (2,1,4,6,2),  4); (2, (2,2,2,2,2), 10)
                ]
            for (number, roll, expected) in cases do
                scoreForNumber number roll |> should equal expected

    module `` countNumber `` =
        
        [<Test>]
        let ``Test`` () =
            countNumber 6 (6,6,3,1,5) |> should equal 2
            countNumber 6 (6,6,6,1,5) |> should equal 3
            countNumber 6 (6,2,5,1,5) |> should equal 1
        
